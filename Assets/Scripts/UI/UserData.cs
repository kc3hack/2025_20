using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserData : MonoBehaviour
{
    [SerializeField]TMP_Text score;
    [SerializeField]TMP_Text combo;
    [SerializeField]DataManager dataManager;
    
    void Start()
    {
        Dictionary<string, int> userData = dataManager.LoadData();
        Debug.Log($"maxScore={userData["HighScore"]}, maxCombo={userData["HighScore"]}");
        score.text = userData["HighScore"].ToString("D5");
        combo.text = userData["HighCombo"].ToString("D2");
    }
}
