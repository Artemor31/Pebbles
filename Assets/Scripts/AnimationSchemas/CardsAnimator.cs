using UnityEngine;

namespace AnimationSchemas
{
    public class CardsAnimator : MonoBehaviour
    {
        public void DisableAnimator()
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}