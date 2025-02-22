using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]bool stopShopkeeper = false;
    [SerializeField]AlertSpriteControler alertSpriteControler;
    [SerializeField]ShopKeeperState currentState = ShopKeeperState.LookingAtKitchen;   //現在のステート
    [SerializeField]int alert = 0;      //警戒値
    [SerializeField, Range(0f, 100f)]float baseProbability = 10f;
    [SerializeField, Range(0f, 20f)]float amount = 10f;
    [SerializeField, Range(0f, 100f)]float turnThreshold = 100;
    [SerializeField, Range(2f, 5f)]float turningTime = 2f;
    [SerializeField]float turnGreed = 0;
    [SerializeField]Animator shopKeeperAnim;
    [SerializeField]Animator alertAnim;
    [SerializeField]ShopKeeperAnimController animController;

    Coroutine lookAtPlayerCoroutine;

    public ShopKeeperState CurrentState{
        get{
            return currentState;
        }
        set{
            currentState = value;
            animController.PlayShopKeeperAnim(currentState);
        }
    }
    public int Alert{
        get{
            return alert;
        }
        set{
            alert = value;
            if(alert > 5)
            {
                alert = 5;
            }
            //アニメーション
            alertSpriteControler.ShowAlert(alert);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currentState = ShopKeeperState.Idling;
    }

    // Update is called once per frame
    public void UpdateShopKeeper()
    {
        //>>>DEV
        if(stopShopkeeper)
        {
            currentState = ShopKeeperState.LookingAtKitchen;
            return;
        }
        if(currentState != ShopKeeperState.Idling)
        {
            //振り向き抽選
            if(currentState == ShopKeeperState.LookingAtKitchen)
            {
                CheckForTurn();
                if(turnGreed >= turnThreshold)
                {
                    //警戒度に応じて振り向いている時間を増やす
                    LookAtPlayer(turningTime + UnityEngine.Random.Range(0f, alert * 0.8f));

                    //animator.SetBool();

                    turnGreed = 0;
                }
            }
        }
    }

    public void LookAtPlayer(float lookingTime)
    {
        if(lookAtPlayerCoroutine != null)
        {
            StopCoroutine(lookAtPlayerCoroutine);
        }

        CurrentState = ShopKeeperState.LookingAtPlayer;
        //アニメーション
        lookAtPlayerCoroutine = StartCoroutine(LookAtPlayerCoroutine(lookingTime));
    }
    IEnumerator LookAtPlayerCoroutine(float lookingTime)
    {
        Debug.Log("LookingAtPlayerCorutine");
        //Playerを見るアニメーション
        
        yield return new WaitForSeconds(lookingTime);

        //Kitchenを見るアニメーション
        CurrentState = ShopKeeperState.LookingAtKitchen;
        

        lookAtPlayerCoroutine = null;
    }

    //DEV
    float deltaTG;
    void CheckForTurn()
    {
        float probability = (baseProbability + alert * amount) / 100f;
        deltaTG = UnityEngine.Random.Range(0f, probability);
        //Debug.Log(deltaTG);
        turnGreed += deltaTG;
    }
}