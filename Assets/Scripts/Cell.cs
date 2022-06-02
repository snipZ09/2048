using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public static Cell instance;
    public int xIndex, yIndex;
    public bool hasTile = false;

    [SerializeField] Color baseColor, offsetColor;
    [SerializeField] SpriteRenderer sRenderer;
    


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
        if(this.transform.childCount != 0)
        {
            hasTile = true;
        }
        else
        {
            hasTile = false;
        }
    }

    public void Init(bool isOffset)
    {
        sRenderer.color = isOffset ? offsetColor : baseColor;
    }
}
