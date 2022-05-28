using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour
{
    public static Tile instance;
    public int amount;
    public float moveSpeed;
    public LayerMask whatStopsMovement;
    bool canMove;
    public int xOffset, yOffset;
    public int stepCanMove;
    bool isHit;
    int xMoveTo, yMoveTo;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        xMoveTo = CellManager.instance.maxX;
        yMoveTo = CellManager.instance.maxY;
    }

    private void Update()
    {
        //float diff = transform.parent.tr - CellManager.instance.maxX;
        var mang = CellManager.instance.allCells;
        Vector2 abc;
        int index = Array.IndexOf(mang, gameObject.transform.parent.gameObject);
        Vector3 diff = transform.position;
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(index < 4)
            {
                //CellManager.instance.cells[0, 3].GetComponent<Cell>().hasTile;
                yMoveTo = 0;
                MoveRight(yMoveTo);
            }
            else if(index < 8)
            {
                yMoveTo = 1;
                MoveRight(yMoveTo);
            }
            else if(index < 12)
            {
                yMoveTo = 2;
                MoveRight(2);
            }
            else if(index < 16)
            {
                yMoveTo = 3;
                MoveRight(yMoveTo);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {

        }
        if (Input.GetKeyDown(KeyCode.W))
        {

        }
        if (Input.GetKeyDown(KeyCode.S))
        {

        }
    }

    public void MoveRight(int row)
    {
        this.xMoveTo = CellManager.instance.maxX;
        //while (this.transform.position != CellManager.instance.cells[row, this.xMoveTo].transform.position)
        //{
        //    while (CellManager.instance.cells[row, this.xMoveTo].GetComponent<Cell>().hasTile)
        //    {
        //        xMoveTo--;
        //    }
        //    if(this.transform.position == CellManager.instance.cells[row, this.xMoveTo].transform.position)
        //    {
        //        return;
        //    }

        //    this.transform.position = CellManager.instance.cells[row, this.xMoveTo].transform.position;
        //    this.transform.parent = CellManager.instance.cells[row, this.xMoveTo].transform;
        //}
        for (this.xMoveTo = 3; xMoveTo > -1; xMoveTo--)
        {
            if(transform.position == CellManager.instance.cells[row, xMoveTo].transform.position)
            {
                return;
            }
            if(!CellManager.instance.cells[row, xMoveTo].GetComponent<Cell>().hasTile)
            {
                transform.position = CellManager.instance.cells[row, xMoveTo].transform.position;
                transform.parent = CellManager.instance.cells[row, xMoveTo].transform;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tile"))
        {
            /*if(amount == other.gameObject.)*/
        }
    }
    
}
