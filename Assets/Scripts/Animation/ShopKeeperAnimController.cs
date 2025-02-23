using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperAnimController : MonoBehaviour
{
    [SerializeField]Animator shopKeeperAnim;

    //Sound
    [SerializeField]SoundManager soundManager;
    [SerializeField]AudioClip turnAudio;

    public void PlayShopKeeperAnim(ShopKeeperState currentState)
    {
        switch(currentState)
        {
            case ShopKeeperState.Idling:
            case ShopKeeperState.LookingAtKitchen:
                soundManager.PlaySoundEffect(turnAudio);
                shopKeeperAnim.SetBool("IsLookingAtPlayer", false);
                Debug.Log("アニメーション：キッチンを見ます");
                break;
            case ShopKeeperState.Turning:
            case ShopKeeperState.LookingAtPlayer:
                soundManager.PlaySoundEffect(turnAudio);
                shopKeeperAnim.SetBool("IsLookingAtPlayer", true);
                Debug.Log("アニメーション：プレイヤーを見ます");
                break;
        }
    }
    
}
