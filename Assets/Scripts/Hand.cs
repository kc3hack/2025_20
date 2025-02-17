using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]Vector3 cursorOffset;
    Vector3 mousePos;
    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x + cursorOffset.x, mousePos.y + cursorOffset.y, 10f));
    }
}