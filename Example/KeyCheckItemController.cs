using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace KeyInputII.Example
{
    public class KeyCheckItemController : MonoBehaviour
    {
        private string keyName;

        [SerializeField]
        private Text keyLabel;

        [SerializeField] 
        private Text keyCodeLabel;

        [SerializeField]
        private Text keyPressed;

        private bool isSeted;
        
        private void Update()
        {
            if (!isSeted)
            {
                return;
            }
            keyPressed.text = KeyInput.I.IsKeyPressed(keyName).ToString();
        }

        public void SetKeyName(string name)
        {
            this.keyName = name;
            keyLabel.text = name;
            var keyList = KeyInput.I.GetKeyList(name);
            if (keyList.Count != 0)
            {
                keyCodeLabel.text = keyList.First().ToString();   
            }
            else
            {
                keyCodeLabel.text = "--";
            }
            isSeted = true;
        }
    }
}