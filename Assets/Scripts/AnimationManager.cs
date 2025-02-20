using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator shopKeeperAnim;

    [SerializeField] Animator playerAnim;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            AnimateShopKeeperLookingAtPlayer();
            AnimatePlayerBombed();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            AnimateShopKeeperLookingAtKitchen();
            AnimatePlayerIdling();
        }
    }

    public void AnimateShopKeeperLookingAtPlayer()
    {
        Debug.Log("アニメーション：プレイヤーを見ます");
        // shopKeeperAnim.SetBool("IsLookingAtPlayer", true);
        shopKeeperAnim.Play("ShopKeeperLookingAtPlayer");
    }

    public void AnimateShopKeeperLookingAtKitchen()
    {
        Debug.Log("アニメーション：キッチンを見ます");
        shopKeeperAnim.SetBool("IsLookingAtPlayer", false);
        // shopKeeperAnim.Play("ShopKeeperLookingAtKitchen");
    }

    public void AnimatePlayerBombed()
    {
        Debug.Log("アニメーション：プレイヤーが爆弾した");
        playerAnim.SetBool("IsPlayerBombed", true);
    }

    public void AnimatePlayerIdling()
    {
        Debug.Log("アニメーション：プレイヤーが復活した");
        playerAnim.SetBool("IsPlayerBombed", false);
    }
}
