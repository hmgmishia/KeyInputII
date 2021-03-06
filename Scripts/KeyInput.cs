﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using KeyInputII.Pairs;
using UnityEngine;

namespace KeyInputII
{
    /// <summary>
    /// キーコンフィグの実行時に使用するクラス
    /// </summary>
    public class KeyInput
    {
        /// <summary>
        /// キー名と対応キーコードのペア辞書
        /// </summary>
        private Dictionary<string, List<KeyCode>> keyConfigDictionary = new Dictionary<string, List<KeyCode>>();
        
        private static KeyInput instance;
        public static KeyInput I
        {
            get
            {
                if (instance == null)
                {
                    instance = new KeyInput();
                }
                return instance;
            }
        }

        /// <summary>
        /// デフォルトパスに保存されている定義データを読み込む
        /// <returns>定義データがあればtrue</returns>
        /// </summary>
        public bool SetDefaultDefine()
        {
            var defaultData = Resources.Load<KeyConfigDefineData>(KeyConfigDefineData.DefaultLoadPath);
            if (defaultData == null)
            {
                return false;
            }
            keyConfigDictionary = defaultData.CreateDictionary();
            return true;
        }

        /// <summary>
        /// 定義データのキーコンフィグを読み込む
        /// </summary>
        /// <param name="data"></param>
        public void SetDefine(KeyConfigDefineData data)
        {
            if (data == null)
            {
                return;
            }
            keyConfigDictionary = data.CreateDictionary();
        }
        
        public string[] GetKeyNameList()
        {
            return keyConfigDictionary.Keys.ToArray();
        }

        /// <summary>
        /// nameに対応した登録されているキーコードを返す
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ReadOnlyCollection<KeyCode> GetKeyList(string name)
        {
            if (!keyConfigDictionary.ContainsKey(name))
            {
                return null;
            }
            return keyConfigDictionary[name].AsReadOnly();
        }

        /// <summary>
        /// nameに対応したキーコードを登録
        /// </summary>
        /// <param name="name"></param>
        /// <param name="keyCodeList"></param>
        public void SetKeyList(string name, List<KeyCode> keyCodeList)
        {
            if (!keyConfigDictionary.ContainsKey(name))
            {
                keyConfigDictionary.Add(name, keyCodeList);
                return;
            }
            keyConfigDictionary[name] = keyCodeList;
        }

        /// <summary>
        /// 設定されたキーコンフィグを割り当て
        /// </summary>
        /// <param name="configSaveData"></param>
        public void SetKeyConfigData(KeyConfigSaveData configSaveData)
        {
            if (configSaveData == null)
            {
                return;
            }
            foreach (var pair in configSaveData.KeyConfigList)
            {
                if (!keyConfigDictionary.ContainsKey(pair.name))
                {
                    keyConfigDictionary.Add(pair.name, pair.codeList);
                    continue;
                }
                keyConfigDictionary[pair.name] = pair.codeList;
            }
        }

        /// <summary>
        /// 設定されたキーコンフィグデータを取得
        /// </summary>
        /// <returns></returns>
        public KeyConfigSaveData GetKeyConfigData()
        {
            var saveData = new KeyConfigSaveData();
            foreach (var pair in keyConfigDictionary)
            {
                saveData.KeyConfigList.Add(new KeyConfigPair(){name = pair.Key, codeList = pair.Value});
            }
            return saveData;
        }
        

        /// <summary>
        /// キーが押された瞬間かどうか返す
        /// </summary>
        /// <param name="name"></param>
        /// <param name="falseWhenAnyKeyPressed">いずれのキーがkeyDown=falseかつkeyPressed=trueだったらfalseを返す</param>
        /// <returns></returns>
        public bool IsKeyDown(string name, bool falseWhenAnyKeyPressed = false)
        {
            if (!keyConfigDictionary.ContainsKey(name) || keyConfigDictionary[name].Count == 0)
            {
                return false;
            }
            var isDown = false;
            var codeList = keyConfigDictionary[name];
            foreach (var code in codeList)
            {
                var down = Input.GetKeyDown(code);
                //falseWhenAnyKeyPressed=trueのときpressedだけどdown=falseのときはreturn false
                if (falseWhenAnyKeyPressed && !down && Input.GetKey(code))
                {
                    return false;
                }
                isDown |= down;
            }
            return isDown;
        }

        /// <summary>
        /// キーが押されているか返す
        /// </summary>
        /// <param name="name"></param>
        /// <param name="trueWhenAllPressed">すべて押してないとtrueにならない</param>
        /// <returns></returns>
        public bool IsKeyPressed(string name, bool trueWhenAllPressed = false)
        {
            if (!keyConfigDictionary.ContainsKey(name) || keyConfigDictionary[name].Count == 0)
            {
                return false;
            }
            bool isPressed = trueWhenAllPressed;
            var codeList = keyConfigDictionary[name];
            foreach (var code in codeList)
            {
                var down = Input.GetKey(code);
                //truewhenallpressedはandで
                if (trueWhenAllPressed)
                {
                    isPressed &= down;
                    continue;
                }
                isPressed |= down;
            }
            return isPressed;
        }
        
        /// <summary>
        /// キーが離れた瞬間かどうか返す
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsKeyUp(string name)
        {
            if (!keyConfigDictionary.ContainsKey(name) || keyConfigDictionary[name].Count == 0)
            {
                return false;
            }
            var isUp = false;          
            var codeList = keyConfigDictionary[name];
            foreach (var code in codeList)
            {
                var up = Input.GetKeyUp(code);
                isUp |= up;
            }
            return isUp;
        } 
    }   
}
