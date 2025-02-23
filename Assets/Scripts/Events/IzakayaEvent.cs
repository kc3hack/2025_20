using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IzakayaEvent : ScriptableObject
{
    public string eventString = "";
    public float lookAtPlayerTime = 3f;
    public Action action;
    public AudioClip audioClip;

    public abstract void Init();
}
