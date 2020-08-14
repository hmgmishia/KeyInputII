using UnityEditor;
using UnityEngine;

namespace KeyInputII.EditorOnly
{
    [CustomPropertyDrawer(typeof(KeySelectWindowAttribute))]
    public class KeySelectWindowPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (GUI.Button(position, $"selectKey:{((KeyCode) property.intValue).ToString()}"))
            {
                KeyCodeSelectWindow.Open(property);
            }
        }
    }
}