using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    public List<Sheep> SheepList;
    public float DisperseDistance;

    // Start is called before the first frame update
    void Start()
    {
        SheepList = new List<Sheep>(GetComponentsInChildren<Sheep>());
    }

    public void DisperseSheepFromPosition()
    {

    }
}
