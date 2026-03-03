using MaskTransitions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Member.kJH.Code.UI
{
    public class MainButton : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        [SerializeField] string sceneName;

        private void Awake()
        {
            startButton.onClick.AddListener(HandleStartButtonClick);
            exitButton.onClick.AddListener(HandleExitButtonClick);
        }

        private async void HandleStartButtonClick()
        {
            TransitionManager.Instance.LoadLevel(sceneName,0);
            await Awaitable.WaitForSecondsAsync(0.8f);

        }


        private void HandleExitButtonClick()
            => Application.Quit();

        private void OnDestroy()
        {
            startButton.onClick.RemoveListener(HandleStartButtonClick);
            exitButton.onClick.RemoveListener(HandleExitButtonClick);
        }
    }
}