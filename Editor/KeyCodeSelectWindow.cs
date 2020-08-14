using UnityEngine;
using UnityEditor;

namespace KeyInputII.EditorOnly
{
    /// <summary>
    /// KeyCodeを選択するウィンドウを表示するクラス
    /// </summary>
    public class KeyCodeSelectWindow : EditorWindow
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        static KeyCodeSelectWindow mainWindow;
        /// <summary>
        /// 代入先プロパティ
        /// </summary>
        SerializedProperty assignTargetProp;
        /// <summary>
        /// スクロール量
        /// </summary>
        Vector2 scrollPosition;
        /// <summary>
        /// 検索文字列
        /// </summary>
        string searchName;

        public static void Open(SerializedProperty assignTargetProp)
        {
            if (assignTargetProp == null)
            {
                Debug.LogError("プロパティがnullです");
                return;
            }
            if (mainWindow == null)
            {
                mainWindow = CreateInstance<KeyCodeSelectWindow>();
            }
            mainWindow.assignTargetProp = assignTargetProp;
            mainWindow.Show();
        }

        private void OnDisable()
        {
            assignTargetProp = null;
        }

        private void OnEnable()
        {
            searchName = "";
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            if (assignTargetProp != null)
            {
                EditorGUILayout.LabelField("選択キー : " + ((KeyCode)assignTargetProp.intValue).ToString());
            }
            searchName = EditorGUILayout.TextField("検索文字", searchName);
            EditorGUILayout.EndVertical();

            GUI.backgroundColor = Color.gray;
            EditorGUILayout.BeginVertical(GUI.skin.box);
            GUI.backgroundColor = Color.white;
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

            foreach (KeyCode value in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (value == KeyCode.LeftApple || value == KeyCode.RightApple)
                {
                    continue;
                }
                //空白であれば検索をしない
                if (searchName != "")
                {
                    if (value.ToString().IndexOf(searchName, System.StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        continue;
                    }
                }
                if (!GUILayout.Button(value.ToString()))
                {
                    continue;
                }
                if (assignTargetProp != null)
                {
                    assignTargetProp.intValue = (int)value;
                    assignTargetProp.serializedObject.ApplyModifiedProperties();
                }
                EditorGUILayout.EndScrollView();
                EditorGUILayout.EndVertical();
                this.Close();
                return;
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

        }
    }

}