using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDrop : Bolt.GlobalEventListener
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Garbage"))
        {
            BoltNetwork.Destroy(other.gameObject);
        }
    }
}
