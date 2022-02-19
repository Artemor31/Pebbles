using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay
{
    public class Pebble : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            transform.position = Pointer.Instance.transform.position;
        }
    }

    public class Pointer : MonoBehaviour
    {
        public static Pointer Instance;

        private void Awake()
        {
            Instance = FindObjectOfType<Pointer>();
        }
    }
}