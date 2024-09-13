using System;
using System.Collections.Generic;
using UnityEngine;

namespace MrHatProduction.Tools
{
    [Serializable]
    public class SerializedDictionary<T1, T2>
    {
        [SerializeField] private List<SerializedKeyValuePair<T1, T2>> _items = null;

        private Dictionary<T1, T2> _dictionary = null;

        public SerializedDictionary()
        {
            
        }

        public void Init()
        {
            _dictionary = new Dictionary<T1, T2>();
            foreach (var item in _items)
            {
                _dictionary.Add(item.Key, item.Value);
            }
        }

        public T2 this[T1 key]
        {
            get => _dictionary[key];
        }

        public bool TryGetValue(T1 key, out T2 value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public void Remove(T1 key)
        {
            _dictionary.Remove(key);
        }
    }
}
