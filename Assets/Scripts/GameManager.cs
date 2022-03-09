using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public bool PlayerTurn { get; set; }
        public bool PlayerReady;
        public bool AiReady;
        [SerializeField] private GameplayWrapper _wrapper;

        private void Start()
        {
            Instance = FindObjectOfType<GameManager>();
            if (Random.Range(0, 2) == 0) 
                PlayerTurn = false;
            StartGameplay();
        }

        private void StartGameplay()
        {
            PlayerTurn = !PlayerTurn;
            _wrapper.StartPebblePickStage();
            StartCoroutine(WaitForPebblesStage());
        }

        private IEnumerator WaitForPebblesStage()
        {
            yield return new WaitForSeconds(2);
            while (PlayerReady == false || AiReady == false)
            {
                yield return new WaitForSeconds(1);
            }
            _wrapper.StartCardsStage();
            StartCoroutine(WaitForValueStage());
        }

        private IEnumerator WaitForValueStage()
        {
            yield return new WaitForSeconds(2);
            while (PlayerReady == false || AiReady == false)
            {
                yield return new WaitForSeconds(1);
            }

            StartCoroutine(_wrapper.ShowOff());
        }
        
        
    }
}