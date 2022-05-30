using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tile : MonoBehaviour
{
    public static Tile instance;
    public int amount;
    public Text amountText;
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
        //Tìm tile đang ở hàng nào
        yOffset = gameObject.GetComponentInParent<Cell>().yIndex;
        //Tìm tile đang ở cột nào
        xOffset = gameObject.GetComponentInParent<Cell>().xIndex;

        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight(yOffset);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft(yOffset);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp(xOffset);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown(xOffset);
        }
    }

    public void MoveRight(int row)
    {
        this.xMoveTo = CellManager.instance.maxX;

        while(transform.position != CellManager.instance.cells[row, xMoveTo].transform.position)
        {
            if(CellManager.instance.cells[row, xMoveTo].GetComponent<Cell>().hasTile)
            {
                if (xMoveTo == CellManager.instance.minX)
                {
                    return;
                }
                xMoveTo--;  
            }
            else
            {
                transform.position = CellManager.instance.cells[row, xMoveTo].transform.position;
                transform.parent = CellManager.instance.cells[row, xMoveTo].transform;
            }
            
        }
    }

    public void MoveLeft(int row)
    {
        this.xMoveTo = CellManager.instance.minX;

        while (transform.position != CellManager.instance.cells[row, xMoveTo].transform.position)
        {
            if (CellManager.instance.cells[row, xMoveTo].GetComponent<Cell>().hasTile)
            {
                if (xMoveTo == CellManager.instance.maxX)
                {
                    return;
                }
                xMoveTo++;
            }
            else
            {
                transform.position = CellManager.instance.cells[row, xMoveTo].transform.position;
                transform.parent = CellManager.instance.cells[row, xMoveTo].transform;
            }

        }
    }

    public void MoveUp(int column)
    {
        this.yMoveTo = CellManager.instance.minY;

        while (transform.position != CellManager.instance.cells[yMoveTo, column].transform.position)
        {
            if (CellManager.instance.cells[yMoveTo, column].GetComponent<Cell>().hasTile)
            {
                if (yMoveTo == CellManager.instance.maxY)
                {
                    return;
                }
                yMoveTo++;
            }
            else
            {
                transform.position = CellManager.instance.cells[yMoveTo, column].transform.position;
                transform.parent = CellManager.instance.cells[yMoveTo, column].transform;
            }

        }
    }

    public void MoveDown(int column)
    {
        this.yMoveTo = CellManager.instance.maxY;

        while (transform.position != CellManager.instance.cells[yMoveTo, column].transform.position)
        {
            if (CellManager.instance.cells[yMoveTo, column].GetComponent<Cell>().hasTile)
            {
                if (yMoveTo == CellManager.instance.minY)
                {
                    return;
                }
                yMoveTo--;
            }
            else
            {
                transform.position = CellManager.instance.cells[yMoveTo, column].transform.position;
                transform.parent = CellManager.instance.cells[yMoveTo, column].transform;
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
