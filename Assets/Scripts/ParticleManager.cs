using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem clickedParticle;

    [SerializeField] ParticleSystem bombParticle;

    // Start is called before the first frame update
    void Start()
    {
        BombEffect(new Vector3(0f, 0f, 0f));
        Debug.Log($"{Camera.main.ScreenToWorldPoint(new Vector3(100f, 100f, 100f))}");
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックされたらパーティクルを出す
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log($"左クリックされた: {Input.mousePosition}");
            // Input.mousePositionで得られるのは**スクリーン座標**
            MouseClickEffect(Input.mousePosition);
        }
    }

    /// <summary>
    /// クリックエフェクトを出します。
    /// 引数はスクリーン座標を渡してください。
    /// マウスのスクリーン座標をワールド座標に変換してからパーティクルの位置に設定しています。
    /// （マウスカーソルのスクリーン座標は`Input.mousePosition`で得られます）
    /// </summary>
    /// <param name="position"></param>
    public void MouseClickEffect(Vector3 position)
    {
        // マウスのスクリーン座標をワールド座標に変換
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(position);
        // 念の為、z座標は0にしておく
        mousePosition.z = 0f;
        // パーティクルの位置をマウスの位置に設定
        clickedParticle.transform.position = mousePosition;
        // パーティクルを再生
        clickedParticle.Play();
    }

    /// <summary>
    /// 爆発エフェクトを出します。
    /// 引数はワールド座標を渡してください。
    /// </summary>
    /// <param name="position"></param>
    public void BombEffect(Vector3 position)
    {
        // Vector3 bombPosition = Camera.main.ScreenToWorldPoint(position);
        // bombPosition.z = 0f;
        bombParticle.transform.position = position;
        bombParticle.Play();
    }

    
}
