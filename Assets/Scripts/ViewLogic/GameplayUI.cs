using UnityEngine;
using UnityEngine.SceneManagement;

namespace ViewLogic
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private GameObject _lostPanel;

        public void Lost()
        {
            _lostPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}
