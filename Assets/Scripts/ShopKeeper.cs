using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]ShopKeeperState currentState = ShopKeeperState.LookingAtKitchen;   //現在のステート
    [SerializeField]int alert = 0;      //警戒値
    [SerializeField, Range(0f, 100f)]float baseProbability = 10f;
    [SerializeField, Range(0f, 20f)]float amount = 10f;
    [SerializeField, Range(0f, 100f)]float turnThreshold = 0;
    [SerializeField, Range(2f, 5f)]float turningTime = 2f;
    [SerializeField]float turnGreed = 0;
    [SerializeField]Animator animator;

    Coroutine lookAtPlayerCoroutine;

    public int Alert{
        set{
            alert = value;
            if(alert > 5)
            {
                alert = 5;
            }
            //アニメーション


        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //currentState = ShopKeeperState.Idoling;
    }

    // Update is called once per frame
    void Update()
    {
        //振り向き抽選
        if(currentState == ShopKeeperState.LookingAtKitchen)
        {
            CheckForTurn();
            if(turnGreed >= turnThreshold)
            {
                //警戒度に応じて振り向いている時間を増やす
                LookAtPlayer(turningTime + UnityEngine.Random.Range(0f, alert * 0.8f));

                //振り向くアニメーション
                currentState = ShopKeeperState.Turning;
                //animator.SetBool();

                turnGreed = 0;
            }
        }
    }

    public void LookAtPlayer(float lookingTime)
    {
        Debug.Log("LookingAtPlayer");
        if(lookAtPlayerCoroutine != null)
        {
            StopCoroutine(lookAtPlayerCoroutine);
        }

        currentState = ShopKeeperState.LookingAtPlayer;
        //アニメーション
        lookAtPlayerCoroutine = StartCoroutine(LookAtPlayerCotrutine(lookingTime));
    }
    IEnumerator LookAtPlayerCotrutine(float lookingTime)
    {
        Debug.Log("LookingAtPlayerCorutine");
        //Playerを見るアニメーション
        //animator.SetBool()
        yield return new WaitForSeconds(lookingTime);

        //Kitchenを見るアニメーション
        currentState = ShopKeeperState.LookingAtKitchen;
        //animator.SetBool()

        lookAtPlayerCoroutine = null;
    }

    //DEV
    float deltaTG;
    void CheckForTurn()
    {
        float probability = (baseProbability + alert * amount) / 200;
        deltaTG = UnityEngine.Random.Range(0f, probability);
        //Debug.Log(deltaTG);
        turnGreed += deltaTG;
    }
}
