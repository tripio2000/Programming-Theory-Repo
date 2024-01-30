using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsDetector : MonoBehaviour
{
    Counter counter;
    private void Start()
    {
        counter = FindObjectOfType<Counter>();
    }
    private void OnTriggerExit(Collider other)
    {
        counter.count += 1;
        counter.CounterText.text = "Count : " + counter.count;
        //Erase old
        Destroy(other.gameObject);
        //Reduce active balls count
        GameManager.instance.ChangeBallCount();
    }
}
