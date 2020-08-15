using System;
using System.Collections.Generic;
using UnityEngine;
using KeyInputII.Attributes;

namespace KeyInputII.Pairs
{
    [Serializable]
    public class KeyConfigPair
    {
        public string name;
        [KeySelectWindow]
        public List<KeyCode> codeList;
    }
}