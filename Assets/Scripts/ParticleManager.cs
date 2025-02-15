using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem clickedParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックされたらパーティクルを出す
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log($"左クリックされた: {Input.mousePosition}");
            // マウスのスクリーン座標をワールド座標に変換
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 念の為、z座標は0にしておく
            mousePosition.z = 0f;
            // パーティクルの位置をマウスの位置に設定
            clickedParticle.transform.position = mousePosition;
            // パーティクルを再生
            clickedParticle.Play();
        }
    }
}
