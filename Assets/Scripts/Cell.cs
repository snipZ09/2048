using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public static Cell instance;
    public bool hasTile;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
