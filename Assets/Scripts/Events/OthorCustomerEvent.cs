using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OthorCustomerEvent : IzakayaEvent
{
    [SerializeField]List<string> otherCustomerHappen;
    public override void Init()
    {
        eventString = otherCustomerHappen[UnityEngine.Random.Range(0, otherCustomerHappen.Count)];
        Debug.Log(eventString);
    }
}
