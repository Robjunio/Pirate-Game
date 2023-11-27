using Gameplay.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Gameplay
{
    public class GameInterface : MonoBehaviour
    {
        [SerializeField] private GameObject GameplayCanvas;
        [SerializeField] private GameObject EndGameCanvas;

        [SerializeField] private TextMeshProUGUI Score;

        private void OnEnable()
        {
            GameController.EndGame += EndGameUI;
        }

        private void EndGameUI()
        {
            if(EndGameCanvas.activeSelf) return;
            
            GameplayCanvas.SetActive(false);
            
            EndGameCanvas.SetActive(true);

            Score.text = ScoreManager.instance.GetCurrentScore().ToString();
        }

        public void GoToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
        
        public void RestartGame()
        {
            SceneManager.LoadScene("Gameplay");
        }

        private void OnDisable()
        {
            GameController.EndGame -= EndGameUI;
        }
    }
}