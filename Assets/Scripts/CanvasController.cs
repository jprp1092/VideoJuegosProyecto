using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    PlayerController character;

    [SerializeField]
    TextMeshProUGUI CoinsCount;

    [SerializeField]
    TextMeshProUGUI SpeedCount;

    [SerializeField]
    TextMeshProUGUI ForceCount;

    [SerializeField]
    TextMeshProUGUI HeartCompleCount;

    void Awake()
    {
        character.OnCoinCountChanged.AddListener(OnCoinCountChanged);
        character.OnForceCountChanged.AddListener(OnForceCountChanged);
        character.OnHeartCompleCountChanged.AddListener(OnHeartCompleCountChanged);
        character.OnSpeedCountChanged.AddListener(OnSpeedCountChanged);
    }

    void OnSpeedCountChanged(int value)
    {
        
        SpeedCount.text = value.ToString();
    }

   void OnHeartCompleCountChanged(int value)
    {
        HeartCompleCount.text = value.ToString();
    }

    void OnForceCountChanged(int value)
    {
        ForceCount.text = value.ToString();
    }

    void OnCoinCountChanged(int value)
    {
        CoinsCount.text = value.ToString();
       
    }



}
