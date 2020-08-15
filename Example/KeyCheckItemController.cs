using System;
using UnityEngine;
using UnityEngine.UI;

namespace KeyInputII.Example
{
    public class KeyCheckItemController : MonoBehaviour
    {
        private string keyName;

        [SerializeField]
        private Text keyLabel;

        private Text keyPressed;
        
        private void Update()
        {
            keyPressed.text = KeyInput.I.IsKeyPressed(name).ToString();
        }

        public void SetKeyName(string name)
        {
            this.keyName = name;
        }
    }
}