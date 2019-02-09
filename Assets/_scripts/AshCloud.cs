using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshCloud : MonoBehaviour
{
    public ParticleSystem ps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Garbage"))
        {
            ps.Play();
        }
    }
}
