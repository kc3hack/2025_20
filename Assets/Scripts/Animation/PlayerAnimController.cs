using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField]Animator playerAnimator;


    public void PlayPlayerAnim(PlayerState currentState)
    {
        switch(currentState)
        {
            case PlayerState.Idling:
            case PlayerState.Waiting:
            case PlayerState.Hovering:
                playerAnimator.SetBool("IsPlayerBombed", false);
                Debug.Log("アニメーション：プレイヤーは爆発していない");
                break;
            case PlayerState.Dipping:
                // カツをディップするアニメーション
                // （終了時にアニメーションイベントでcurrentStateをIdlingに変更する）
                // Debug.Log("アニメーション：カツをディップします");
                // カツを食べるアニメーション（開始時にアニメーションイベントでEat関数を呼び出す）
                // （終了時にアニメーションイベントでcurrentStateをWaitingに変更する）
                // Debug.Log("アニメーション：カツを食べます");
                break;
            case PlayerState.GameOver:
                playerAnimator.SetBool("IsPlayerBombed", true);
                Debug.Log("アニメーション：プレイヤーは爆発した");
                break;
        }
    }
    
}
