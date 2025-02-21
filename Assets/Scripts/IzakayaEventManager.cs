using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class IzakayaEventmanager : MonoBehaviour
{
    [SerializeField]ShopKeeper shopKeeper;
    [SerializeField]SoundManager soundManager;
    [SerializeField]GameObject hukidashiObj;
    [SerializeField]GameObject hukidashiTextObj;
    [SerializeField]GameObject hukidashiKushiObj;
    [SerializeField]GameObject hukidashikushiTextObj;
    [SerializeField]List<IzakayaEvent> izakayaEventList; 
    [SerializeField]IzakayaEvent currentEvent;
    [SerializeField]int drawProbability = 10;
    [SerializeField]int baseProbability = 50;
    [SerializeField, Range(1000, 10000)]int drawFrame = 1000;
    Coroutine hukidashiCoroutine = null;
    Coroutine hukidashiKushiCorutine = null;
    TMP_Text hukidashiText;
    TMP_Text hukidashiKushiText;
    [SerializeField]float drawCapacity;

    void Start()
    {
        drawCapacity = 0f;
        hukidashiText = hukidashiTextObj.GetComponent<TMP_Text>();
        hukidashiKushiText = hukidashikushiTextObj.GetComponent<TMP_Text>();
        //Debug.Log(hukidashiText);
    }

    public void UpdateIzakayaEvent()
    {
        if(gameObject.activeInHierarchy)
        {
            if(shopKeeper.CurrentState == ShopKeeperState.LookingAtKitchen)
            {
                DrawingEvent();
            }
        }
    }

    //抽選
    void DrawingEvent()
    {
        drawCapacity += UnityEngine.Random.Range(0f, drawProbability/100f) * 100f;
        if(drawCapacity >= drawFrame)
        {
            drawCapacity = 0f;
            Debug.Log("抽選1");
            if(UnityEngine.Random.Range(0f, 1f) < baseProbability/100f)
            {
                Debug.Log("抽選2");
                currentEvent = izakayaEventList[UnityEngine.Random.Range(0, izakayaEventList.Count)];
                currentEvent.Init();
                ExecuteEvent();
            }
        }
    }

    void ExecuteEvent()
    {
        ShowHukidashi();
        PlayAudio();
        currentEvent.action?.Invoke();
    }
    void PlayAudio()
    {
        //soundManager.PlaySoundEffect(currentEvent.audioIndex);
    }
    void ShowHukidashi()
    {
        hukidashiText.text = currentEvent.eventString.ToString();
        Debug.Log(hukidashiText.text);
        //吹き出しを表示
        hukidashiObj.SetActive(true);
        hukidashiTextObj.SetActive(true);

        if(hukidashiCoroutine != null)
        {
            StopCoroutine(hukidashiCoroutine);
            hukidashiCoroutine = null;
        }
        hukidashiCoroutine = StartCoroutine(ShowHukidashiCorutine());
        ForceTurnSK(currentEvent.lookAtPlayerTime);
    }
    IEnumerator ShowHukidashiCorutine()
    {
        //2秒待つ
        yield return new WaitForSeconds(2f);
        
        hukidashiCoroutine = null;

        //吹き出しを閉じる
        hukidashiObj.SetActive(false);
        hukidashiTextObj.SetActive(false);
    }

    IEnumerator ShowHukidashiKushiCorutine()
    {
        yield return new WaitForSeconds(2f);
        
        hukidashiKushiCorutine = null;

        hukidashiKushiObj.SetActive(false);
        hukidashikushiTextObj.SetActive(false);
    }

    public void ForceTurnSK(float turningTime)
    {
        shopKeeper.LookAtPlayer(turningTime);
    }

    public void KushiEvent(string text)
    {
        hukidashiKushiText.text = text;
        hukidashiKushiObj.SetActive(true);
        hukidashikushiTextObj.SetActive(true);
        if(hukidashiKushiCorutine != null)
        {
            StopCoroutine(hukidashiKushiCorutine);
            hukidashiKushiCorutine = null;
        }

        hukidashiKushiCorutine = StartCoroutine(ShowHukidashiKushiCorutine());

        ForceTurnSK(3f);
    }
}