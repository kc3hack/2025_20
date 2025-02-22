using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperAnimController : MonoBehaviour
{
    [SerializeField] Animator shopKeeperAnim;


    public void PlayShopKeeperAnim(ShopKeeperState currentState)
    {
        switch(currentState)
        {
            case ShopKeeperState.Idling:
            case ShopKeeperState.LookingAtKitchen:
                shopKeeperAnim.SetBool("IsLookingAtPlayer", false);
                break;
            case ShopKeeperState.Turning:
            case ShopKeeperState.LookingAtPlayer:
                shopKeeperAnim.SetBool("IsLookingAtPlayer", true);
                break;
        }
    }
    
}
