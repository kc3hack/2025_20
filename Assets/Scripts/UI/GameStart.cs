using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void OnClickStartButton()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("SampleScene");
    }

}
