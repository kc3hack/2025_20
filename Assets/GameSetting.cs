using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameSettings : MonoBehaviour
{
    public SceneStack scenes;
    public Timer timer; // Timerの参照を追加

    public void OnClickReturnButton()
    {
       var scene = scenes.Pop();
        SceneManager.LoadSceneAsync(scene.buildIndex);
    }

    public void OpenSettingsScreen()
    {
        timer.OpenSettingsScreen(); // 設定スクリーンを開くときにタイマーを停止
    }

    public void CloseSettingsScreen()
    {
        timer.CloseSettingsScreen(); // 設定スクリーンを閉じるときにタイマーを再開
    }

    public void InitTimer()
    {
        timer.InitTimer(); // TimerのInitTimerメソッドを呼び出す
    }
}