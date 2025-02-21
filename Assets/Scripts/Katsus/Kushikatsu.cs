using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Kushikatsu : MonoBehaviour
{
    public event Action<string> OnSpecialEffect;   //デバフ串の時特殊効果を発動するイベント
    [SerializeField]Sprite baseSprite;  //基本スプライト
    [SerializeField]Sprite topSprite;   //ソース付きスプライト
    [SerializeField]string comment = "";
    [SerializeField]int kushiLength;    //串の長さ
    [SerializeField]int baseKushiScore = 10;
    [SerializeField]float offsetY; //スプライト間のY軸オフセット
    [SerializeField]Vector3 offsetPos;
    [SerializeField]bool isDipped = false;  //ソースがついているかどうか
    GameObject[] _kushiPieces;
    const int maxKushiLength = 7; //串の最大長
    int kushiScore = 0;
    public int KushiLength{
        get{
            return kushiLength;
        }
        protected set{
            kushiLength = value;
        }
    }
    public int KushiScore{
        get{
            return kushiScore;
        }
    }
    public bool IsDipped{
        set{
            isDipped = value;
            UpdateSprite();
        } 
    }


    void Awake()
    {
        //ランダムに串の長さを指定
        kushiLength = UnityEngine.Random.Range(1, maxKushiLength+1);
        //長さ6は除外
        if(kushiLength == 5 || kushiLength == 6)
        {
            kushiLength = 4;
        }

        //得点を計算
        for(int i = 1; i < kushiLength+1; i++)
        {
            kushiScore += baseKushiScore * i;
        }
        Debug.Log(kushiScore);

        CreateSprite();
    }


    //playerクラスに公開
    public void EatKushikatsu()
    {
        Debug.Log("EatKushikatsu!");
        //食べるときに先端をDestroy
        if(kushiLength > 0)
        {
            Destroy(_kushiPieces[kushiLength - 1]);
            _kushiPieces[kushiLength - 1] = null;
            Debug.Log("sentan Destroy");
        }

        kushiLength--;
        isDipped = false;

        //カツがなくなったら、破壊
        if(kushiLength <= 0)
        {
            ApplySpecialEffect();
            Destroy(gameObject);
            return;
        }

        //スプライトをアップデート
        UpdateSprite();
    }

    void CreateSprite()
    {
        _kushiPieces = new GameObject[KushiLength];

        for(int i = 0; i < KushiLength; i++)
        {
            GameObject piece = new GameObject("KushiPiece_" + i);
            piece.transform.SetParent(transform);
            piece.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            piece.transform.localPosition = new Vector3(offsetPos.x, offsetPos.y + i * offsetY, 0f);
            SpriteRenderer renderer = piece.AddComponent<SpriteRenderer>();
            renderer.sprite = baseSprite;
            renderer.sortingOrder = 3;
            _kushiPieces[i] = piece;
        }
    }

    void UpdateSprite()
    {
        for(int i = 0; i < _kushiPieces.Length; i++)
        {
            if(_kushiPieces[i] != null)
            {
                //ソースにつけられているなら先端の見た目を変える
                SpriteRenderer renderer = _kushiPieces[i].GetComponent<SpriteRenderer>();
                if(i == KushiLength - 1)
                {
                    renderer.sprite = isDipped ? topSprite : baseSprite;
                }
                else
                {
                    renderer.sprite = baseSprite;
                }
            }
        }
    }

    public void ApplySpecialEffect()
    {
        Debug.Log(OnSpecialEffect);
        if(OnSpecialEffect == null)
        {
            Debug.Log("普通の串！");
        }
        else
        {
            Debug.Log("OnSpecialEffect");
            OnSpecialEffect?.Invoke(comment);
            //OnSpecialEffect();
        }
    }
}