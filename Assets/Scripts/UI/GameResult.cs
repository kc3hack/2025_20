using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameResult : MonoBehaviour
{
    [SerializeField]Player player;
    [SerializeField]GameObject exitGameButton;
    [SerializeField]TMP_Text scoreText;
    [SerializeField]TMP_Text comboText;
    [SerializeField]Animator scoreTextAnim;
    [SerializeField]Animator comboTextAnim;
    [SerializeField]float animationDelay = 1f;

    void OnEnable()
    {
        //Debug.Log("GameResult OnEnable!");
        
        ShowResult();
    }

    void ShowResult()
    {
        scoreText.text = ((int)player.Score).ToString("D5");
        comboText.text = player.MaxCombo.ToString("D2");

        //Scoreの表示
        scoreText.gameObject.SetActive(true);
        scoreTextAnim.Play(0, 0, 0f);
        StartCoroutine(DelayShowingText());

        StartCoroutine(EnableButtonCoroutine());
    }
    
    //順番に表示させる
    IEnumerator DelayShowingText()
    {
        yield return new WaitForSecondsRealtime(animationDelay);

        comboText.gameObject.SetActive(true);
        comboTextAnim.Play(0, 0, 0f);
    }


    //2秒待ってからStartに戻れるようにする
    IEnumerator EnableButtonCoroutine()
    {
        //Debug.Log("EnableButtonCoroutine");
        yield return new WaitForSecondsRealtime(2f);

        exitGameButton.SetActive(true);
    }
}
