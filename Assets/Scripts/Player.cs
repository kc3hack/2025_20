using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]Dish dish;
    [SerializeField]Hand hand;
    [SerializeField]Kushikatsu currentKushi;
    [SerializeField]PlayerState currentState = PlayerState.Idling;
    [SerializeField]double score = 0;
    [SerializeField]Animator playerAnim;
    [SerializeField]GameScore gameScore;
    [SerializeField]GameCombo gameCombo;
    [SerializeField]Vector3 mouseOffset;
    [SerializeField]PlayerAnimController animController;

    //
    [SerializeField]SoundManager soundManager;
    [SerializeField]AudioClip dippingAudio;
    [SerializeField]AudioClip eatAudio;
    
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
            gameScore.Score = (int)score;
            //Debug.Log(score);
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
            gameCombo.Combo = combo;
            //Debug.Log(combo);
        }
    }
    public int MaxCombo{
        get{ return maxCombo; }
    }

    public PlayerState CurrentState{
        get{ return currentState; }
        set{
            currentState = value;
            Debug.Log($"currentStateのSettarを実行: {currentState}");
            animController.PlayPlayerAnim(currentState);
            if(currentState == PlayerState.GameOver)
            {
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
        currentState = PlayerState.Idling;

        // //>>>>>>>>>>>DEV
        // CurrentState = PlayerState.Waiting;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentKushi == null)
        {
            TakeKushi();
        }
        if(currentState == PlayerState.Waiting || currentState == PlayerState.Hovering)
        {
            // //カツをマウスの位置に
            mousePos = Input.mousePosition + mouseOffset;
            mousePos.z = -Camera.main.transform.position.z;
            mousePosWorldPoint = Camera.main.ScreenToWorldPoint(mousePos);
            mousePosWorldPoint.z = 0f;
            // currentKushi.transform.position = mousePosWorldPoint;

            //handをマウスの位置にワープ
            hand.transform.position = mousePosWorldPoint;

            //マウスクリック
            if(Input.GetMouseButtonDown(0))
            {
                if(currentState == PlayerState.Hovering)
                {
                    //たれの上をホバーしていたら
                    Dipping();

                    //>>>>>>>>>>>>DEV
                    //Eat();
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

    public void Dipping()
    {
        soundManager.PlaySoundEffect(dippingAudio);
        CurrentState = PlayerState.Dipping;
        currentKushi.IsDipped = true;
    }

    public void SetKushiState()
    {
        //カツの見た目を変更
        currentKushi.IsDipped = true;
    }


    public void Eat()
    {
        soundManager.PlaySoundEffect(eatAudio);
        //カツを食べる
        currentKushi.EatKushikatsu();
        //Debug.Log(currentKushi.KushiLength);

        //前の串が無くなったら
        if(currentKushi.KushiLength <= 0)
        {
            Combo++;
            Score += currentKushi.KushiScore * (1 + 0.1 * combo);
            currentKushi.DestroyKushi();
            currentKushi = null;
            TakeKushi();
        }
    }
}