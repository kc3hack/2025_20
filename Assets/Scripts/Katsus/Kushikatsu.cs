using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Kushikatsu : MonoBehaviour
{
    public event Action OnSpecialEffect;   //デバフ串の時特殊効果を発動するイベント
    [SerializeField]Sprite baseSprite;  //基本スプライト
    [SerializeField]Sprite topSprite;   //ソース付きスプライト
    [SerializeField]int kushiLength;    //串の長さ
    [SerializeField]float offsetY = 1f; //スプライト間のY軸オフセット
    [SerializeField]bool isDipped = false;  //ソースがついているかどうか
    GameObject[] _kushiPieces;
    int maxKushiLength = 7; //串の最大長

    public int KushiLength{
        get{
            return kushiLength;
        }
        protected set{
            kushiLength = value;
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
        if(kushiLength == 6)
        {
            kushiLength = 4;
        }

        CreateSprite();
    }

    //playerクラスに公開
    public void EatKushikatsu()
    {
        kushiLength--;
        isDipped = false;
        //カツがなくなったら、破壊Destroy
        if(kushiLength <= 0)
        {
            ApplySpecialEffect();
            Destroy(gameObject);
            return;
        }
        UpdateSprite();
    }

    void CreateSprite()
    {
        if(_kushiPieces != null)
        {
            foreach(GameObject piece in _kushiPieces)
            {
                Destroy(piece);
            }
        }

        _kushiPieces = new GameObject[KushiLength];

        for(int i = 0; i < KushiLength; i++)
        {
            GameObject piece = new GameObject("KushiPiece_" + i);
            piece.transform.SetParent(transform);
            //>>>修正必要かも
            piece.transform.localPosition = new Vector3(0, i * offsetY, 0);
            SpriteRenderer renderer = piece.AddComponent<SpriteRenderer>();
            renderer.sprite = baseSprite;
            _kushiPieces[i] = piece;
        }
        UpdateSprite();
    }

    void UpdateSprite()
    {
        for(int i = 0; i < _kushiPieces.Length; i++)
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
            //食べたら非表示
            _kushiPieces[i].SetActive(i < KushiLength);
        }
    }

    public virtual void ApplySpecialEffect()
    {
        if(OnSpecialEffect == null)
        {
            Debug.Log("普通の串！");
        }
        else
        {
            OnSpecialEffect();
        }
    }
}
