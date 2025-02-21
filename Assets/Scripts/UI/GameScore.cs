using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameScore : MonoBehaviour
{
    [SerializeField]GameObject scoreTextObj;
    TMP_Text scoreText;
    int score = 0;

    public int Score{
        set{
            score = value;
            scoreText.text = score.ToString("D5");
            Debug.Log(scoreText.text);
        }
    }

    void Start()
    {
        scoreText = scoreTextObj.GetComponent<TMP_Text>();
        //score = score.ToString();
        scoreText.text = score.ToString("D5");
    }
}
