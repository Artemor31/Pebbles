using UnityEngine;

namespace Gameplay
{
    public class AnimatorDisable : MonoBehaviour
    {
        public void Disable()
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}