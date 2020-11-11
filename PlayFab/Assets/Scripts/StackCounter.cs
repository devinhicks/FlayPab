using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCounter : MonoBehaviour
{
    public static int count;

    public void Start()
    {
        count = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slab"))
            count++;
        Debug.Log(count);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Slab"))
            count--;
        Debug.Log(count);
    }
}
