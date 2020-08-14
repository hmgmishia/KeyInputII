using System;
using System.Collections.Generic;
using KeyInputII.Pairs;
using UnityEngine;

namespace KeyInputII
{
    [Serializable]
    public class KeyConfigSaveData
    {
        [SerializeField]
        private List<KeyConfigPair> keyConfigList;
        public List<KeyConfigPair> KeyConfigList { get => keyConfigList; set => keyConfigList = value; }
    }
}