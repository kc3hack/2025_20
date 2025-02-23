using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem clickedParticle;

    [SerializeField] ParticleSystem eatParticle;

    [SerializeField] ParticleSystem dipSourceParticle;

    [SerializeField] ParticleSystem bombParticle;

    [SerializeField] List<ParticleSystem> happeningParticleList;


    /// <summary>
    /// クリックエフェクトを出します。
    /// マウスのスクリーン座標をワールド座標に変換してからパーティクルの位置に設定しています。
    /// （マウスカーソルのスクリーン座標は`Input.mousePosition`で得られます）
    /// </summary>
    /// <param name="position">エフェクトを出す座標。スクリーン座標</param>
    /// <param name="scale">エフェクトのスケール。デフォルトで１</param>
    public void MouseClickEffect(Vector3 position, float scale = 1f)
    {
        // マウスのスクリーン座標をワールド座標に変換
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(position);
        // 念の為、z座標は0にしておく
        mousePosition.z = 0f;
        // パーティクルの位置をマウスの位置に設定
        clickedParticle.transform.position = mousePosition;
        clickedParticle.transform.localScale = new Vector3(scale, scale, 1f);
        // パーティクルを再生
        clickedParticle.Play();
    }

    /// <summary>
    /// 爆発エフェクトを出します。
    /// 引数はワールド座標を渡してください。
    /// </summary>
    /// <param name="position">エフェクトを出す座標。ワールド座標</param>
    /// param name="scale">エフェクトのスケール。デフォルトで１</param>
    public void BombEffect(Vector3 position, float scale = 1f)
    {
        // Vector3 bombPosition = Camera.main.ScreenToWorldPoint(position);
        // bombPosition.z = 0f;
        bombParticle.transform.position = position;
        bombParticle.transform.localScale = new Vector3(scale, scale, 1f);
        bombParticle.Play();
        Debug.Log("BOOOOM!");
    }

    /// <summary>
    /// 串を食べるときのエフェクトを出します。
    /// </summary>

    public void EatEffect(Vector3 position, float scale = 1f)
    {
        eatParticle.transform.position = position;
        eatParticle.transform.localScale = new Vector3(scale, scale, 1f);
        eatParticle.Play();
    }

    /// <summary>
    /// 串をソースに付けたときのエフェクトを出します。
    /// </summary>
    /// <param name="position">エフェクトを出す座標。ワールド座標</param>
    /// <param name="scale">エフェクトのスケール。デフォルトで１</param>
    public void DipSourceEffect(Vector3 position, float scale = 1f)
    {
        dipSourceParticle.transform.position = position;
        dipSourceParticle.transform.localScale = new Vector3(scale, scale, 1f);
        dipSourceParticle.Play();
    }


    /// <summary>
    /// ハプニング串に対してエフェクトを出します
    /// 引数はワールド座標を渡してください。
    /// </summary>
    /// <param name="particleNumber">どのエフェクトを出すか</param>
    /// <param name="position">エフェクトを出す座標。ワールド座標</param>
    /// <param name="scale">エフェクトのスケール。デフォルトで１</param>
    public void HappeningKushiEffectPlay(int particleNumber, Vector3 position, float scale = 1f)
    {
        happeningParticleList[particleNumber].transform.position = position;
        happeningParticleList[particleNumber].transform.localScale = new Vector3(scale, scale, 1f);
        happeningParticleList[particleNumber].Play();
    }

    /// <summary>
    /// ハプニング串に対してエフェクトを止めます
    /// </summary>
    /// <param name="particleNumber">どのエフェクトを止めるか</param>
    public void HappeningKushiEffectStop(int particleNumber)
    {
        happeningParticleList[particleNumber].Stop();
    }
    
}
