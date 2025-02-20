using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]Dish dish;
    [SerializeField]Kushikatsu currentKushi;
    [SerializeField]PlayerState currentState = PlayerState.Idling;
    [SerializeField]double score = 0;
    [SerializeField]Animator playerAnim;
    
    int combo = 0;
    int maxCombo = 0;
    [SerializeField]
    bool previousHovering = false;


    Vector3 mousePos;
    Vector3 mousePosWorldPoint;

    public double Score{
        get{ return score; }
        set{
            score = value;
            //UI変更イベント処理
        }
    }
    public int Combo{
        get{
            return combo;
        }
        set{
            combo = value;
            if(combo > maxCombo)
            {
                maxCombo = combo;
            }
            Debug.Log($"current combo value: {combo}");
        }
    }
    public int MaxCombo{
        get{ return maxCombo; }
    }

    public PlayerState CurrentState{
        get{ return currentState; }
        set{
            currentState = value;
            if(currentState == PlayerState.GameOver)
            {
                //アニメーション
                //playerAnim.SetTrigger();
                Debug.Log($"current state: {currentState}");
            }
            previousHovering = false;
        }
    }

    public bool PreviousHovering{
        get{ return previousHovering; }
        set{ previousHovering = value; }
    }

    void Start()
    {
        //currentState = PlayerState.Idling;

        //>>>>>>>>>>>DEV
        currentState = PlayerState.Waiting;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentKushi == null)
        {
            currentKushi = dish.GetKushikatsu();
        }
        if(currentState == PlayerState.Waiting || currentState == PlayerState.Hovering)
        {
            //カツをマウスの位置に
            mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z;
            mousePosWorldPoint = Camera.main.ScreenToWorldPoint(mousePos);
            mousePosWorldPoint.z = 0f;
            currentKushi.transform.position = mousePosWorldPoint;

            //マウスクリック
            if(Input.GetMouseButtonDown(0))
            {
                if(currentState == PlayerState.Hovering)
                {
                    //たれの上をホバーしていたら
                    Dipping();

                    //>>>>>>>>>>>>DEV
                    Eat();
                }
            }
        }
    }

    void TakeKushi()
    {
        //串を取ってくる
        currentKushi = dish.GetKushikatsu();

        //一口食べるアニメーション
    }

    void Dipping()
    {
        currentState = PlayerState.Dipping;

        //アニメーション
        //playerAnim.SetTrigger();
    }

    public void SetKushiState()
    {
        //カツの見た目を変更
        currentKushi.IsDipped = true;
    }


    public void Eat()
    {
        int kushiLengthCash = currentKushi.KushiLength;
        //操作を無効化
        currentState = PlayerState.Idling;

        //アニメーション
        //playerAnim.SetTrigger();

        //串を食べる処理
        currentKushi.EatKushikatsu();

        //前の串が無くなったら
        if(kushiLengthCash <= 0)
        {
            Score += currentKushi.KushiScore * (1 + 0.1 * combo);
            TakeKushi();
        }

        //操作可能に
        currentState = PlayerState.Waiting;
    }
}