using System;
using System.Linq;
using System.Reflection;
using KeyInputII.Attributes;
using UnityEditor;
using UnityEngine;

namespace KeyInputII.EditorOnly
{
    [CustomPropertyDrawer(typeof(KeyConfigNameAttribute))]
    public class KeyConfigNamePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                base.OnGUI(position, property, label);
                return;
            }

            var value = property.stringValue;
            
            var keyconfig = attribute as KeyConfigNameAttribute;
            var target = property.serializedObject.targetObject;
            var field = target.GetType().GetField(keyconfig.FieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetProperty);
            var define = field.GetValue(target) as KeyConfigDefineData;
            if (define == null)
            {
                base.OnGUI(position, property, label);
                return;
            }

            var nameList = define.GetKeyNameList();
            var selectIndex = Array.IndexOf(nameList, value);
            if (selectIndex < 0) selectIndex = 0;
            property.stringValue = nameList[EditorGUI.Popup(position, label.text, selectIndex, nameList)];
        }
    }
}