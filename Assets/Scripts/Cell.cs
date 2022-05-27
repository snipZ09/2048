using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public static Cell instance;
    public float xOffset, yOffset;
    public LayerMask isCell;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
