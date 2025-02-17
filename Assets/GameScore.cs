using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameScore : MonoBehaviour
{
    Text ScoreResult;
    string score;

    void Start()
    {
        ScoreResult = GetComponent<Text>();
        score = score.ToString();
        ScoreResult.text = score;
    }

}
