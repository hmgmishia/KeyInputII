using System;
using System.Collections.Generic;
using KeyInputII.Pairs;
using UnityEngine;

namespace KeyInputII
{
    /// <summary>
    /// キーコンフィグのセーブデータ
    /// </summary>
    [Serializable]
    public class KeyConfigSaveData
    {
        [SerializeField]
        private List<KeyConfigPair> keyConfigList = new List<KeyConfigPair>();
        public List<KeyConfigPair> KeyConfigList { get => keyConfigList; set => keyConfigList = value; }
    }
}