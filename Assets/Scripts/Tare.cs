using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tare : MonoBehaviour
{
    [SerializeField]Player player;


    void OnTriggerEnter2D(Collider2D collision)
    {
        player.CurrentState = PlayerState.Hovering;
        Debug.Log("OnTriggerEnter2D");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.CurrentState = PlayerState.Waiting;
        Debug.Log("OnTriggerExit2D");
    }
}