using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private int Count = 5;

    private void Start()
    {
        Count = 5;
        CounterText.text = "Lives: " + Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        Count -= 1;
        CounterText.text = "Lives: " + Count;
    }
}
