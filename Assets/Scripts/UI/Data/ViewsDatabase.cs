using MrHatProduction.Tools;
using UI.Views;
using UnityEngine;

namespace UI.Data
{
    [CreateAssetMenu(fileName = "Views Database", menuName = "UI/Views Database", order = 0)]
    public class ViewsDatabase : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<EView, View> _database = null;

        private void OnValidate()
        {
            _database.Init();
        }

        public bool TryGet(EView viewID, out View view)
        {
            return _database.TryGetValue(viewID, out view);
        }
    }
}