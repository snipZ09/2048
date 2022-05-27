using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public static Cell instance;
    public Cell cLeft;
    public Cell cRight;
    public Cell cUp;
    public Cell cDown;
    public float xOffset, yOffset;
    public LayerMask isCell;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach(Cell cell in CellManager.instance.allCells)
        {
            CheckAround(cell.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CheckAround(Vector3 cellPosition)
    {
        RaycastHit hit;
        if (Physics2D.OverlapCircle(cellPosition + new Vector3(0f, yOffset, 0f), .2f, isCell))
        {
            
        }
            bool roomLeft = Physics2D.OverlapCircle(cellPosition + new Vector3(-xOffset, 0f, 0f), .2f, isCell);
            bool roomRight = Physics2D.OverlapCircle(cellPosition + new Vector3(xOffset, 0f, 0f), .2f, isCell);
            bool roomBelow = Physics2D.OverlapCircle(cellPosition + new Vector3(0f, -yOffset, 0f), .2f, isCell);
    }
}
