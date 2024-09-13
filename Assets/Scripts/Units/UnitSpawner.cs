using Units.Data;
using UnityEngine;

namespace Units
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private UnitController _unitPrefab = null;

        [Header("Debug Data")]
        [SerializeField] private Unit _basicUnit = null;
        [SerializeField] private Unit _shooterUnit = null;
        [SerializeField] private Unit _meleeUnit = null;

        public UnitController Spawn(Unit unit)
        {
            var unitController = Instantiate(_unitPrefab, transform.position, Quaternion.identity);
            unitController.Init(unit);

            return unitController;
        }

        public UnitController Spawn(Unit unit, Transform parent)
        {
            var unitController = Instantiate(_unitPrefab, parent);
            unitController.Init(unit);

            return unitController;
        }

        [ContextMenu("Spawn Basic Unit")]
        private void SpawnBasicUnit()
        {
            Spawn(_basicUnit);
        }
        
        [ContextMenu("Spawn Shooter Unit")]
        private void SpawnShooterUnit()
        {
            Spawn(_shooterUnit);
        }

        [ContextMenu("Spawn Melee Unit")]
        private void SpawnMeleeUnit()
        {
            Spawn(_meleeUnit);
        }
    }
}