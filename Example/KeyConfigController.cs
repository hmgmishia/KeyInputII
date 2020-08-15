using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeyInputII.Example
{
    public class KeyConfigController : MonoBehaviour
    {
        [SerializeField]
        private KeyConfigDefineData defineData;

        [SerializeField]
        private KeyConfigItemController prefab;

        [SerializeField] 
        private ScrollRect parent;

        [SerializeField]
        private GameObject panel;
        
        private KeyConfigItemController item;

        private void Start()
        {
            var keyList = defineData.GetKeyNameList();
            foreach (var key in keyList)
            {
                var instance = Instantiate(prefab, parent.content);
                instance.SetKey(key);
                instance.OnChanging += () =>
                {
                    item = instance;
                    panel.gameObject.SetActive(true);
                };
            }
        }

        private void Update()
        {
            if (item == null)
            {
                return;
            }
            if (!Input.anyKeyDown)
            {
                return;
            }

            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {

                if (Input.GetKeyDown(code))
                {
                    if (code != KeyCode.Escape)
                    {
                        item.SetKeyCode(code);
                    }
                    item = null;
                    panel.gameObject.SetActive(false);

                    break;
                }
            }
        }
    }
}