using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class KyakuirEvent : IzakayaEvent
{
    public override void Init()
    {
        lookAtPlayerTime = UnityEngine.Random.Range(2f, 5f);
    }
}
