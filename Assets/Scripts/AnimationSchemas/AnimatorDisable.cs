using UnityEngine;

namespace AnimationSchemas
{
    public class AnimatorDisable : MonoBehaviour
    {
        public void Disable()
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}