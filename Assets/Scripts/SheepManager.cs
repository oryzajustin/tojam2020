using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    private List<Sheep> SheepList;

    void Start()
    {
        SheepList = new List<Sheep>(GetComponentsInChildren<Sheep>());
    }

    public void DisperseSheepFromPosition(Vector3 position)
    {
        foreach (Sheep sheep in SheepList)
        {
            sheep.DisperseFromPosition(position);
        }
    }
}
