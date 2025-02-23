using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSetting : MonoBehaviour
{
    [SerializeField]GameObject settingsPanel;
    [SerializeField]Timer timer;
    [SerializeField]Player player;
    
    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
        if(settingsPanel.activeSelf == true)
        {
            //設定を開いたら操作不可能にする
            //previousState = player.CurrentState;
            //player.CurrentState = PlayerState.Idling;
            timer.StopTimer();
        }
        else
        {
            timer.StartTimer();
            //設定を閉じたら操作可能にする
            //player.CurrentState = PlayerState.Waiting;
        }
    }
}
