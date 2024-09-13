using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;


namespace MrHatProduction.Tools.Editor
{
    [CustomPropertyDrawer(typeof(SerializedDictionary<,>), true)]
    public class SerializedDictionaryDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement container = new VisualElement();
            
            container.Add(new PropertyField(property.FindPropertyRelative("_items"), property.name));

            return container; //base.CreatePropertyGUI(property);
        }
    }
}