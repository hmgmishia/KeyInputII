using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KeyInputII.Pairs;
using UnityEngine;

namespace KeyInputII.Example
{
    /// <summary>
    /// ロードとセーブをする
    /// </summary>
    public class LoadKeyConfig : MonoBehaviour
    {
        public void Save()
        {
            var saveData = KeyInput.I.GetKeyConfigData();
            var jsonData = JsonUtility.ToJson(saveData);
            File.WriteAllText(KeyConfigPath(), jsonData);
        }

        [RuntimeInitializeOnLoadMethod]
        private static void LoadDefineData()
        {
            //定義データをまず読み込む
            Debug.Assert(KeyInput.I.SetDefaultDefine(), "KeyConfigRuntimeCore.Instance.DefaultLoad() is false");
            if (!File.Exists(KeyConfigPath()))
            {
                return;
            }
            
            string jsonData = File.ReadAllText(KeyConfigPath());
            var saveData = JsonUtility.FromJson<KeyConfigSaveData>(jsonData);
            KeyInput.I.SetKeyConfigData(saveData);
        }

        private static string KeyConfigPath()
        {
#if UNITY_EDITOR
            return Application.dataPath + "/../keyconfig.json";
#endif
            return Application.persistentDataPath + "/keyconfig.json";
        }
    }
}