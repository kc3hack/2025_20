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

public class GameSetting : MonoBehaviour
{

    public SceneStack scenes;

    public void OnClickReturngButton()
    {
        var scene = scenes.Pop();
        SceneManager.LoadSceneAsync(scene.buildIndex);
    }

}
