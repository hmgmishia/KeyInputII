using UnityEngine;

namespace KeyInputII.Attributes
{
    /// <summary>
    /// キーコンフィグの定義名をPopupで選べるようにする
    /// </summary>
    public class KeyConfigNameAttribute : PropertyAttribute
    {
        /// <summary>
        /// KeyConfigDefineDataのフィールド名
        /// </summary>
        public string FieldName { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="fieldName">KeyConfigDefineDataのフィールド名</param>
        public KeyConfigNameAttribute(string fieldName)
        {
            this.FieldName = fieldName;
        }
    }
}