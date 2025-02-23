using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]int maxScore;
    [SerializeField]int maxCombo;


    const string HighScoreKey = "HighScore";
    const string HighComboKey = "HighCombo";

    public void InitData()
    {
        PlayerPrefs.SetInt(HighScoreKey, 0);
        PlayerPrefs.SetInt(HighComboKey, 0);
        PlayerPrefs.Save();
        LoadData();
        Debug.Log("初期化完了");
    }

    public void SaveData(double score, int combo)
    {
        int ms = PlayerPrefs.GetInt(HighScoreKey);
        int mc = PlayerPrefs.GetInt(HighComboKey);
        
        //スコアを超えたとき
        if(score > ms)
        {
            maxScore = (int)score;
            PlayerPrefs.SetInt(HighScoreKey, (int)score);
            Debug.Log("ハイスコアを更新しました: " + (int)maxScore);
        }
        if(combo > mc)
        {
            maxCombo = combo;
            PlayerPrefs.SetInt(HighComboKey, combo);
            Debug.Log("ハイスコアを更新しました: " + maxCombo);
        }
        PlayerPrefs.Save();
        Debug.Log("SaveData!");
    }

    public Dictionary<string, int> LoadData()
    {
        Dictionary<string, int> userData = new Dictionary<string, int>();
        int maxScore = PlayerPrefs.GetInt(HighScoreKey);
        int maxCombo = PlayerPrefs.GetInt(HighComboKey);

        userData.Add(HighScoreKey, maxScore);
        userData.Add(HighComboKey, maxCombo);
        Debug.Log($"maxScore={maxScore}, maxCombo={maxCombo}");

        return userData;
    }
}
