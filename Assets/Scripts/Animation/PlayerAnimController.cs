using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField]Animator playerAnimator;

    [SerializeField]Animator kushiAnimator;


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
                Debug.Log("アニメーション：カツをディップして食べます。");
                playerAnimator.SetTrigger("IsPlayerDipping");
                break;
            case PlayerState.GameOver:
                playerAnimator.SetBool("IsPlayerBombed", true);
                Debug.Log("アニメーション：プレイヤーは爆発した");
                break;
        }
    }
    
}
