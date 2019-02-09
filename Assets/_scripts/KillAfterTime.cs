using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfterTime : MonoBehaviour
{
    float kill_time = 0.0f;
    bool time_to_kill = false;

    // Start is called before the first frame update
    void Start()
    {
        time_to_kill = true;
        kill_time = Time.time + 5.0f;
        print("Attached!");
    }

    // Update is called once per frame
    void Update()
    {
        if (time_to_kill && kill_time < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
