using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    //Audio
    [SerializeField]SoundManager soundManager;
    [SerializeField]AudioClip countDownAudio;
    [SerializeField]AudioClip doraAudio;

    //
    [SerializeField]TMP_Text countdownText;
    [SerializeField]int countdownDefault = 3;
    public bool IsRunning{ get; private set;}
    int countdown = 0;

    public int CountdownDefault{
        set{ countdownDefault = value; }
    }


    void OnEnable()
    {
        countdown = countdownDefault;
        ShowCountdown(countdownDefault);
    }

    public void StartCountDown(int countDownSecond, string endMessage, float timeScale)
    {
        //動作中だったら無視
        if(IsRunning)
        {
            return;
        }
        IsRunning = true;
        countdown = countDownSecond;
        countdownText.gameObject.SetActive(true);

        StartCoroutine(CountDownCoroutine(endMessage, timeScale));
    }

    IEnumerator CountDownCoroutine(string endMessage, float gameTimeScale)
    {
        for(int i = countdown; i >= 0; i--)
        {
            if(i > 0)
            {
                soundManager.PlaySoundEffect(countDownAudio, 0.8f);
                ShowCountdown(i);
                Debug.Log(i);
            }
            else
            {
                soundManager.PlaySoundEffect(doraAudio, 0.7f);
                countdownText.text = endMessage;
                StartCoroutine(HideCoundDonwCoroutine());
                Debug.Log(gameTimeScale);
            }

            yield return new WaitForSecondsRealtime(1f);
        }
        Time.timeScale = gameTimeScale;
    }

    //2秒後に隠す
    IEnumerator HideCoundDonwCoroutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        countdownText.gameObject.SetActive(false);
        IsRunning = false;
    }


    void ShowCountdown(int second)
    {
        countdownText.text = second.ToString();
    }
}
