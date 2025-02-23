using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class GameSetting : MonoBehaviour
{

    public SceneStack scenes;

    public void OnClickReturngButton()
    {
        var scene = scenes.Pop();
        SceneManager.LoadSceneAsync(scene.buildIndex);
    }

}
