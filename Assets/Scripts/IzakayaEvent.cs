using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzakayaEvent : MonoBehaviour
{
    [SerializeField]ShopKeeper shopKeeper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ForceTurnSK()
    {
        //2秒間強制的に振り向かせる
        shopKeeper.LookAtPlayer(3f);
    }
}