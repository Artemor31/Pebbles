using System.Collections;
using UnityEngine;

namespace Utils
{
    public class CoroutineRunner : MonoBehaviour
    {
        public void RunCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}