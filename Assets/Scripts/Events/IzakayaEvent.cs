using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IzakayaEvent : ScriptableObject
{
    public int audioIndex;
    public string eventString = "";
    public float lookAtPlayerTime = 3f;
    public Action action;

    public abstract void Init();
}
