using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft = 0;
    [SerializeField, Range(1f, 1000f)]float timeLimit = 90f;
    [SerializeField]bool isRunning = false;

    void Awake()
    {
        InitTimer();
    }


    // Update is called once per frame
    void Update()
    {
        if(isRunning)
        {
            timeLeft -= Time.deltaTime;
        }
    }
    
    //タイマー初期化
    public void InitTimer()
    {
        timeLeft = timeLimit;
    }

    //タイマー開始
    public void StartTimer()
    {
        isRunning = true;
    }

    //タイマー停止
    public void StopTimer()
    {
        isRunning = false;
    }
}