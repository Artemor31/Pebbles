using UnityEngine;

namespace Gameplay
{
    public class CardsAnimator : MonoBehaviour
    {
        public void DisableAnimator()
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}