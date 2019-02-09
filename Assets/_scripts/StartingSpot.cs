using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSpot : MonoBehaviour
{
    static List<StartingSpot> spots = new List<StartingSpot> ();

    public static StartingSpot GetRandomStartingSpot()
    {
        return spots[Random.Range(0, spots.Count)];
    }

    // Start is called before the first frame update
    void Start()
    {
        spots.Add(this);
    }

   

    private void OnDestroy()
    {
        spots.Remove(this);
    }
}
