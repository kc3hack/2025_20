using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameCombo : MonoBehaviour
{
    [SerializeField]GameObject comboTextObj;
    TMP_Text comboText;
    int combo = 0;

    public int Combo{
        set{
            combo = value;
            comboText.text = combo.ToString("D2");
        }
    }

    void Start()
    {
        comboText = comboTextObj.GetComponent<TMP_Text>();
        //combo = combo.ToString();
        comboText.text = combo.ToString("D2");
    }
}
