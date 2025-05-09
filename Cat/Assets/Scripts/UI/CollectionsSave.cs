using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsSave : MonoBehaviour
{
    public static CollectionsSave instance;
    public bool[] gotcollections;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        Screen.SetResolution(1600, 1000, false);
    }

    public void AddCollections(int num)
    {
        gotcollections[num] = true;
    }

}
