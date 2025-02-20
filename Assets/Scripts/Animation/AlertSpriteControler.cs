using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlertSpriteControler : MonoBehaviour
{
    [SerializeField]GameObject alertSpriteObj;
    [SerializeField]GameObject alertValueObj;
    Animator alertSpriteAnim;
    Animator alertValueAnim;
    TMP_Text alertValueText;
    // Start is called before the first frame update
    void Start()
    {
        alertSpriteAnim = alertSpriteObj.GetComponent<Animator>();
        alertValueAnim = alertValueObj.GetComponent<Animator>();
        alertValueText = alertValueObj.GetComponent<TMP_Text>();
    }


    public void ShowAlert(int v)
    {
        if(alertSpriteObj.activeSelf == false)
        {
            ShowAlertSprite();
        }
        ShowAlertValue(v);
    }

    void ShowAlertSprite()
    {
        alertSpriteObj.SetActive(true);
        alertSpriteAnim.Play(0, 0, 0f);
    }

    void ShowAlertValue(int v)
    {
        if(alertValueObj.activeSelf == false)
        {
            alertValueObj.SetActive(true);
        }
        alertValueText.text = v.ToString();
        alertValueAnim.Play(0, 0, 0f);
    }
}
