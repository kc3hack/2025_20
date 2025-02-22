using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;


    public void PlayPlayerAnim(PlayerState currentState)
    {
        switch(currentState)
        {
            case PlayerState.Idling:
            case PlayerState.Waiting:
            case PlayerState.Hovering:
            case PlayerState.Dipping:
                playerAnimator.SetBool("IsPlayerBomd", false);
                break;
            case PlayerState.GameOver:
                playerAnimator.SetBool("IsPlayerBomd", true);
                break;
        }
    }
    
}
