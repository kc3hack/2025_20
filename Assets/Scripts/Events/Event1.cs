using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Event1 : IzakayaEvent
{
    public override void Init()
    {
        action += DEVMETHOD1;
        action += DEVMETHOD2;
    }

    void DEVMETHOD1()
    {
        Debug.Log("Event1 DEV1!");
    }
    void DEVMETHOD2()
    {
        Debug.Log("Event1 DEV2!");
    }
}
