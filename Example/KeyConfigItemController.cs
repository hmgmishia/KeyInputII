using System;
using System.Collections.Generic;
using System.Linq;
using KeyInputII.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace KeyInputII.Example
{
    public class KeyConfigItemController : MonoBehaviour
    {
        private string keyName;
        
        [SerializeField] 
        private Text keyLabel;
        
        [SerializeField] 
        private Text buttonKeyLabel;

        public event Action OnChanging;

        public void SetKey(string keyName)
        {
            this.keyName = keyName;
            keyLabel.text = keyName;
            
            var codeList = KeyInput.I.GetKeyList(keyName);
            var code = KeyCode.None;
            if (codeList.Count == 0)
            {
                KeyInput.I.SetKeyList(keyName, new List<KeyCode>(){code});
                buttonKeyLabel.text = code.ToString();
                return;
            }
            code = codeList.First();
            KeyInput.I.SetKeyList(keyName, new List<KeyCode>(){code});
            buttonKeyLabel.text = code.ToString();
        }

        public void OnChangeButton()
        {
            OnChanging?.Invoke();
        }

        public void DeleteKey()
        {
            var code = KeyCode.None;
            KeyInput.I.SetKeyList(keyName, new List<KeyCode>(){code});
            buttonKeyLabel.text = code.ToString();
        }

        public void SetKeyCode(KeyCode code)
        {
            KeyInput.I.SetKeyList(keyName, new List<KeyCode>(){code});
            buttonKeyLabel.text = code.ToString();
        }
    }
}