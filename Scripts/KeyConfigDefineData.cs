using System.Collections.Generic;
using KeyInputII.Pairs;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace KeyInputII
{
    /// <summary>
    /// キーコンフィグの定義アセット
    /// </summary>
    public class KeyConfigDefineData : ScriptableObject
    {
        public const string DefaultLoadPath = "DefaultKeyConfig";
        [SerializeField]
        private List<KeyConfigPair> keyConfigList;

#if UNITY_EDITOR
        [MenuItem("KeyConfig/Create Define Asset")]
        private static void Create()
        {
            var instance = CreateInstance<KeyConfigDefineData>();
            AssetDatabase.CreateAsset(instance, $"Assets/Plugins/KeyInputII/Resources/{DefaultLoadPath}.asset");
            AssetDatabase.SaveAssets();
        }
#endif

        public Dictionary<string, List<KeyCode>> CreateDictionary()
        {
            var dic = new Dictionary<string, List<KeyCode>>();
            foreach (var pair in keyConfigList)
            {
                if (dic.ContainsKey(pair.name))
                {
                    continue;
                }
                dic.Add(pair.name, pair.codeList);
            }
            return dic;
        }
    }
}