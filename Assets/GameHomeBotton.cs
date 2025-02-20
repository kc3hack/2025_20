using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHome : MonoBehaviour
{

    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("StartScene");
    }

}
