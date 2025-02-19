using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IzakayaEventmanager : MonoBehaviour
{
    [SerializeField]ShopKeeper shopKeeper;
    [SerializeField]SoundManager soundManager;
    [SerializeField]GameObject hukidashiObj;
    [SerializeField]GameObject hukidashiTextObj;
    [SerializeField]List<IzakayaEvent> izakayaEventList; 
    [SerializeField]IzakayaEvent currentEvent;
    [SerializeField]int drawProbability = 10;
    [SerializeField]int baseProbability = 50;
    [SerializeField, Range(1000, 10000)]int drawFrame = 1000;
    Coroutine hukidashiCoroutine = null;
    TMP_Text hukidashiText;
    [SerializeField]float drawCapacity;

    void Start()
    {
        drawCapacity = 0f;
        hukidashiText = hukidashiTextObj.GetComponent<TMP_Text>();
        Debug.Log(hukidashiText);
    }

    public void UpdateIzakayaEvent()
    {
        if(shopKeeper.CurrentState == ShopKeeperState.LookingAtKitchen)
        {
            DrawingEvent();
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
            float DEV = UnityEngine.Random.Range(0f, 1f);
            Debug.Log(DEV);
            if(DEV < baseProbability/100f)
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
        //吹き出しを表示
        hukidashiObj.SetActive(true);
        hukidashiTextObj.SetActive(true);

        if(hukidashiCoroutine != null)
        {
            StopCoroutine(hukidashiCoroutine);
        }
        hukidashiCoroutine = StartCoroutine(ShowHukidashiCorutine());
        ForceTurnSK(2f);
    }
    IEnumerator ShowHukidashiCorutine()
    {
        //2秒待つ
        yield return new WaitForSeconds(2f);

        //吹き出しを閉じる
        hukidashiObj.SetActive(false);
        hukidashiTextObj.SetActive(false);
    }

    void ForceTurnSK(float turningTime)
    {
        shopKeeper.LookAtPlayer(turningTime);
    }

    public void ForceTurnSK()
    {
        //2秒間強制的に振り向かせる
        shopKeeper.LookAtPlayer(3f);
    }
}