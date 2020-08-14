using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using KeyInputII.EditorOnly;
#endif

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