﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

namespace Gameplay
{
    public class PlayerHolder : MonoBehaviour
    {
        public static PlayerHolder Instance;

        public int PebblesLeft => _pebblesLeft;
        public int PebblesPicked => _pebblesPicked;
        public int PickedCard { get; set; }
        
        [SerializeField] private List<SpriteRenderer> _fistPebbles;
        [SerializeField] private List<SpriteRenderer> _handPebbles;
        [SerializeField] private SpriteRenderer _noPebbleSign;

        private int _pebblesLeft;
        private int _pebblesPicked;
        private int _pebbles;

        private void Start()
        {
            Instance = FindObjectOfType<PlayerHolder>();
        }

        public void SetupFist()
        {
            _noPebbleSign.enabled = false;
            for (var i = 0; i < _fistPebbles.Count; i++)
            {
                _fistPebbles[i].enabled = false;
                _handPebbles[i].enabled = false;
            }

            _pebblesPicked = FindObjectOfType<HandHolder>().GetPebblesCount();
            if (_pebblesPicked == 0)
            {
                _noPebbleSign.enabled = true;
                return;
            }
            
            for (int i = 0; i < _pebblesPicked; i++)
            {
                _fistPebbles[i].enabled = true;
                _handPebbles[i].enabled = true;
            }
        }
    }
}