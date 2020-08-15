using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KeyInputII.Example
{
    public class KeyCheckController : MonoBehaviour
    {
        [SerializeField]
        private KeyConfigDefineData defineData;

        [SerializeField]
        private KeyCheckItemController prefab;

        [SerializeField] 
        private ScrollRect parent;

        [SerializeField]
        private string configSceneName;
        
        private void Start()
        {
            var keyList = defineData.GetKeyNameList();
            foreach (var key in keyList)
            {
                var instance = Instantiate(prefab, parent.content);
                instance.SetKeyName(key);
            }
        }

        public void OnChangeConfigScene()
        {
            SceneManager.LoadScene(configSceneName);
        }
    }
}