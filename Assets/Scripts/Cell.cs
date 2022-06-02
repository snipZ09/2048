using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public static Cell instance;
    public int xIndex, yIndex;
    [SerializeField] Color baseColor, offsetColor;
    [SerializeField] SpriteRenderer sRenderer;
    


    private void Awake()
    {
        instance = this;
    }

    public void Init(bool isOffset)
    {
        sRenderer.color = isOffset ? offsetColor : baseColor;
    }
}
