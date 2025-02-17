using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Objects
    [SerializeField]Player player;
    [SerializeField]ShopKeeper shopKeeper;
    [SerializeField]Timer timer;
    [SerializeField]GameState currentGameState;

    //UI
    [SerializeField]GameObject resultPanel;



    // Start is called before the first frame update
    void Start()
    {
        //>>>>>>>>>DEV
        currentGameState = GameState.Playing;
    }
    void FixedUpdate()
    {
        if(currentGameState == GameState.Playing)
        {
            GameUpdate();
        }
    }


    void GameUpdate()
    {
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

    void GameOver()
    {
        player.CurrentState = PlayerState.Idling;
        shopKeeper.CurrentState = ShopKeeperState.Idling;
        currentGameState = GameState.GameOver;
        timer.StopTimer();
        //Time.timeScale = 0;

        Debug.Log("GameOver!");
    }

    void TimeOver()
    {
        player.CurrentState = PlayerState.Idling;
        shopKeeper.CurrentState = ShopKeeperState.Idling;
        currentGameState = GameState.TimeOver;

        ShowResult();
        Debug.Log("TimeOver!");
    }

    void ShowResult()
    {
        currentGameState = GameState.Result;
        resultPanel.SetActive(true);
    }
}