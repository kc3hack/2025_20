using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField]Animator playerAnimator;
    [SerializeField]Animator kushiAnimator;

    //Audio
    [SerializeField]SoundManager soundManager;
    [SerializeField]AudioClip bombAudio;


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
                kushiAnimator.SetTrigger("IsKushiDipped");
                playerAnimator.SetTrigger("IsPlayerDipping");
                break;
            case PlayerState.GameOver:
                soundManager.PlaySoundEffect(bombAudio);
                playerAnimator.SetBool("IsPlayerBombed", true);
                Debug.Log("アニメーション：プレイヤーは爆発した");
                break;
        }
    }
    
}
