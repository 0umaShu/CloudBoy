using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class uiManager : MonoBehaviour
{
    [Header ("Death Counter")]
    [SerializeField] public TextMeshProUGUI deathCounter;
    [SerializeField] private FloatSO deathCounterSO;

    [Header ("TimeUI")]
    [SerializeField] public TextMeshProUGUI timeDisplay;
    [SerializeField] private FloatSO timeCounter;  
    private float timeDuration = 0f;


    //References
    private playerRespawn pRespawn;


    private void Awake()
    {
        pRespawn = GetComponent<playerRespawn>();
    }
    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (timeCounter.Value >= 0)
        {
            timeCounter.Value += Time.deltaTime;
            UpdateTimerDisplay(timeCounter.Value);
        }
        if (deathCounterSO.Value >= 0)
        {
            UpdateDeathCounter(deathCounterSO.Value);
        }
    }

    private void ResetTimer()
    {
        timeCounter.Value += timeDuration;
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("Time : {00:00}:{1:00}", minutes, seconds);
        timeDisplay.text = currentTime.ToString();

    }

    private void UpdateDeathCounter(float deaths)
    {
        string currentDeathCounter = string.Format("Deaths : {0}", deaths);
        deathCounter.text = currentDeathCounter.ToString();
    }
    
}
