using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class BootLoader : MonoBehaviour
    {
        public void LoadScene(int index) => SceneManager.LoadScene(index);
    }
}