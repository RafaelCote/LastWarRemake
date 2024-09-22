using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Units;
using Units.Data;
using UnityEngine;

namespace Player
{
    public class InventoryManager : MonoBehaviour
    {
        public event Action AllUnitLost;
        
        [SerializeField] private UnitSpawner _unitSpawner = null;
        [SerializeField] private Transform _unitsContainer = null;
        [SerializeField] private Unit _basicUnit = null;

        [Header("Placement Values")]
        [SerializeField] private float _spacing = 0.0f;

        private ObservableCollection<UnitController> _units;
        private int _rowModulo = 3;

        private void Awake()
        {
            _units = new ObservableCollection<UnitController>();
            _units.CollectionChanged += Units_OnCollectionChanged;

            UnitController.PlayerTransform = transform;
        }

        [ContextMenu("Spawn Unit")]
        public void SpawnUnit() //TODO: Refactor with UnitSpawner class
        {
            var unitController = _unitSpawner.Spawn(_basicUnit, _unitsContainer);
            unitController.gameObject.layer = LayerMask.NameToLayer("Player Units");
            unitController.Died += UnitController_Died;
            _units.Add(unitController);

            if (_units.Count >= Mathf.Pow(_rowModulo, 2))
                _rowModulo++;
        }

        public void AddUnits(int unitAmount)
        {
            for (int i = 0; i < unitAmount; i++)
            {
                SpawnUnit();
            }
        }

        public void RemoveUnit(UnitController unit)
        {
            _units.Remove(unit);

            if (_units.Count <= 0) 
                AllUnitLost?.Invoke();
        }

        private void RemoveLastUnit()
        {
            if (_units.Count < 1)
                return;
            
            RemoveUnit(_units[_units.Count - 1]);
        }
        
        public void RemoveUnits(int unitAmount)
        {
            for (int i = 1; i <= unitAmount; i++) 
                RemoveLastUnit();
        }

        public void MakeUnitsUseAbility()
        {
            foreach (var unit in _units)
            {
                unit.UseAbility();
            }
        }

        private void Units_OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add || args.Action == NotifyCollectionChangedAction.Remove)
                OrderUnits();
        }

        private void UnitController_Died(UnitController unit)
        {
            unit.Died -= UnitController_Died;
            RemoveUnit(unit);
        }

        private void OrderUnits()
        {
            for (int i = 1; i < _units.Count; i++)
            {
                var columnIndex = GetColumn(i);
                var half = _rowModulo / 2;
                if (columnIndex > half)
                    columnIndex = -GetColumn(columnIndex - half);
                _units[i].transform.localPosition = new Vector3(columnIndex * _spacing, 0.0f, -GetRow(i) * _spacing);
            }
        }

        private int GetRow(int index) => ((index) / _rowModulo);
        private int GetColumn(int index) => ((index) % _rowModulo);
    }
}