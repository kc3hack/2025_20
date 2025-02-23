using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

[CreateAssetMenu]
public class SceneStack : ScriptableObject
{
    private Stack<Scene> scenes = new Stack<Scene>();

    // シーンをスタックから取り出す
    public Scene Pop()
    {
        return scenes.Pop();
    }

    // シーンをスタックに積む
    public void Push(Scene scene)
    {
        scenes.Push(scene);
    }
}

public class SceneLoader : MonoBehaviour
{
    public SceneStack scenes;
    public SceneAsset scene;

    public void Load()
    {
        scenes.Push(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(scene.name);
    }
}

public class GameSettings : MonoBehaviour
{

    public SceneStack scenes;
    public GameTimer timer; // GameTimerの参照を追加

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
        timer.InitTimer(); // GameTimerのInitTimerメソッドを呼び出す
    }
}