using System;
using UnityEngine;

namespace Gameplay
{
    public class Pointer : MonoBehaviour
    {
        public static Pointer Instance;
        private Camera _camera;

        private void Awake()
        {
            Instance = FindObjectOfType<Pointer>();
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) == false) return;
        }
    }
}