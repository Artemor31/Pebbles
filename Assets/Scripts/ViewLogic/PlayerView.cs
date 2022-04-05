using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Image _avatarImage;
    [SerializeField] private Sprite _avatarSprite;
    [SerializeField] private GameObject[] _pebbles;

    

    private void ShowPebbles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _pebbles[i].SetActive(true);
        }
    }

    private void ShowAvatar()
    {
        _avatarImage.sprite = _avatarSprite;
    }
}
