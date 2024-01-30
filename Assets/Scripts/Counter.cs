using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    public int count = 0;

    private void Start()
    {
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        count += 1;
        CounterText.text = "Count : " + count;
        //Erase old
        Destroy(other.gameObject);
        //Reduce active balls count
        GameManager.instance.ChangeBallCount();
    }
}
