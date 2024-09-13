using System;

namespace MrHatProduction.Tools
{
    [Serializable]
    public struct SerializedKeyValuePair<TKey, TValue> //TODO: Improve Inspector Visual.
    {
        public TKey Key;
        public TValue Value;
    }
}