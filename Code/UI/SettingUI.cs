using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Member.kJH.Code.UI
{
    public class SettingUI : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        
        public void GoToTitle()
        {
            SceneManager.LoadScene(sceneName);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
