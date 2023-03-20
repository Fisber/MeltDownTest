using System;
using SO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private UIEventsHolder UIEventsHolder;
        [SerializeField] private GameObject WinPopup;
        [SerializeField] private GameObject FailPopup;
        [SerializeField] private GameObject PlayBottom;
        [SerializeField] private GameObject Canvas;

        private void Start()
        {
            UIEventsHolder.OnFailPopup += ShowFailPopup;
            UIEventsHolder.OnWinPopup += ShowWinPopup;
            UIEventsHolder.OnPlayClick += HideCanvas;
        }

        private void OnDestroy()
        {
            UIEventsHolder.OnFailPopup -= ShowFailPopup;
            UIEventsHolder.OnWinPopup -= ShowWinPopup;
            UIEventsHolder.OnPlayClick -= HideCanvas;
        }
        
        private void HideCanvas()
        {
            Canvas.SetActive(false);
        }

        private void ShowWinPopup()
        {
            Canvas.SetActive(true);
            WinPopup.SetActive(true);
            PlayBottom.SetActive(false);
        }

        private void ShowFailPopup()
        {
            Canvas.SetActive(true);
            FailPopup.SetActive(true);
            PlayBottom.SetActive(false);
        }

        public void ResetGame()
        {
            var sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }

        public void Play()
        {
            UIEventsHolder.IsEndGame = false;
            UIEventsHolder.OnPlayClick?.Invoke();
        }
    }
}