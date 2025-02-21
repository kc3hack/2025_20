using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameResult : MonoBehaviour
{
    [SerializeField]Player player;
    [SerializeField]GameObject scoreResultObj;
    [SerializeField]GameObject comboResultObj;
    [SerializeField]GameObject exitGameButton;

    TMP_Text scoreText;
    TMP_Text comboText;

    void Start()
    {
        scoreText = scoreResultObj.GetComponent<TMP_Text>();
        comboText = comboResultObj.GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        Debug.Log("GameResult OnEnable!");
        ShowResult();
    }

    void ShowResult()
    {
        scoreText.text = ((int)player.Score).ToString("D5");
        comboText.text = player.MaxCombo.ToString("D2");

        StartCoroutine(EnableButtonCoroutine());
        Debug.Log("ShowResult!");
    }

    //2秒待ってからStartに戻れるようにする
    IEnumerator EnableButtonCoroutine()
    {
        Debug.Log("EnableButtonCoroutine");
        yield return new WaitForSecondsRealtime(2f);

        exitGameButton.SetActive(true);
    }
}
