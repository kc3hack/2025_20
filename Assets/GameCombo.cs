using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameCombo : MonoBehaviour
{
    Text ComboResult;
    string combo;

    void Start()
    {
        ComboResult = GetComponent<Text>();
        combo = combo.ToString();
        ComboResult.text = combo;
    }
}
