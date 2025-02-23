using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Objects
    [SerializeField]Player player;
    [SerializeField]ShopKeeper shopKeeper;
    [SerializeField]IzakayaEventmanager izakayaEvent;
    [SerializeField]Timer timer;
    [SerializeField]CountDown countDown;
    [SerializeField]GameState currentGameState;
    [SerializeField]GameObject middleFinger;

    //Audio
    [SerializeField]SoundManager soundManager;
    [SerializeField]AudioClip bombAduio;

    //UI
    [SerializeField]GameObject resultPanel;

    public bool IsAlreadyStart{ get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        IsAlreadyStart = false;
        Time.timeScale = 0f;
        currentGameState = GameState.Idling;
        countDown.StartCountDown(3, "START!", 1f);
    }

    void FixedUpdate()
    {
        if(IsAlreadyStart == false)
        {
            StartGame();
        }
        if(currentGameState == GameState.Playing)
        {
            GameUpdate();
        }
    }

    void GameUpdate()
    {
        izakayaEvent.UpdateIzakayaEvent();
        shopKeeper.UpdateShopKeeper();
        if(shopKeeper.CurrentState == ShopKeeperState.LookingAtPlayer)
        {
            if(player.CurrentState == PlayerState.Hovering && player.PreviousHovering == false) //警戒値上昇
            {
                player.PreviousHovering = true;
                //shopkeeperの警戒値を1上昇
                shopKeeper.Alert++;
                //playerのコンボを減らす
                player.Combo = 0;
            }
            else if(player.CurrentState == PlayerState.Dipping) //爆死
            {
                //gameOverにする
                GameOver();

                return;
            }
        }
        if(timer.timeLeft <= 0f)
        {
            TimeOver();
        }
        currentGameState = GameState.Playing;
    }

    void StartGame()
    {
        IsAlreadyStart = true;
        currentGameState = GameState.Playing;
        player.CurrentState = PlayerState.Waiting;
        shopKeeper.CurrentState = ShopKeeperState.LookingAtKitchen;
        timer.StartTimer();
    }

    void GameOver()
    {
        middleFinger.SetActive(true);
        player.CurrentState = PlayerState.GameOver;
        shopKeeper.CurrentState = ShopKeeperState.Idling;
        currentGameState = GameState.GameOver;
        timer.StopTimer();

        //ShowResult();
        StartCoroutine(GameOverCoroutine());
    }

    void TimeOver()
    {
        player.CurrentState = PlayerState.Idling;
        shopKeeper.CurrentState = ShopKeeperState.Idling;
        currentGameState = GameState.TimeOver;

        ShowResult();
        Debug.Log("TimeOver!");
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSecondsRealtime(3f);

        ShowResult();
    }
    
    void ShowResult()
    {
        Time.timeScale = 0;
        timer.StopTimer();
        currentGameState = GameState.Result;
        resultPanel.SetActive(true);
    }
}