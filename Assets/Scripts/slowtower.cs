using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowtower : MonoBehaviour
{
    public string tagstring;
    [SerializeField] float slowdown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagstring)
        {
            other.GetComponent<agentscript>().slowdown(slowdown);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == tagstring)
        {
            other.GetComponent<agentscript>().speedup(slowdown);
        }

    }
}
