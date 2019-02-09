using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageMaker : Bolt.GlobalEventListener
{
    private float last_spawned_at = 0.0f;
    private float spawn_at = 0.0f;
    public float minimum_wait = 60f;
    public float maximum_wait = 300f;


    public override void SceneLoadLocalDone(string map)
    {
        spawn_at = Time.deltaTime + spawn_frequency();
    }

    private void Update()
    {
       if (BoltNetwork.IsServer && spawn_at <= Time.fixedTime)
        {
            if (!detect_garbage())
            {
                BoltNetwork.Instantiate(BoltPrefabs.Garbage_1, transform.position, Quaternion.identity);
            }
            spawn_at = Time.fixedTime + spawn_frequency();
        }
    }

    private float spawn_frequency()
    {
        return Random.Range(minimum_wait, maximum_wait);
    }

    private bool detect_garbage()
    {
        var hits = Physics.SphereCastAll(transform.position, 1.0f, Vector3.up, 1.0f);

        foreach(var hit in hits)
        {
            if(hit.transform.gameObject.CompareTag("Garbage"))
            {
                return true;
            }
        }
        return false;
    }
}
