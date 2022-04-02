using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrostructure
{
    public class BootLoader : MonoBehaviour
    {
        public void LoadScene(int index) => SceneManager.LoadScene(index);
    }
}