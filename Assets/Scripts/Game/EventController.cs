using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController current;

    public event Action onPlayerRoll;
    public event Action onPlayerRotate;

    void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerRoll()
    {
        if (onPlayerRoll != null)
        {
            onPlayerRoll();
        }
    }

    public void PlayerRotate()
    {
        if (onPlayerRotate != null)
        {
            onPlayerRotate();
        }
    }
}
