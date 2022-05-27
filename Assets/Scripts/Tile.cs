using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static Tile instance;
    public int amount;
    public float moveSpeed;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    bool canMove;
    public int xOffset, yOffset;
    public int stepCanMove;
    bool isHit;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
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

    public Transform CheckNextMove(string direction)
    {
        while (canMove)
        {
            if (direction == "Horizontal")
            {
                Debug.Log("move Horizontal");
                movePoint.position += new Vector3(Input.GetAxisRaw(direction) * xOffset, 0f, 0f);
                isHit = Physics2D.OverlapCircle(movePoint.localPosition, 0.2f, whatStopsMovement);
                while (!isHit)
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw(direction) + xOffset * stepCanMove, 0f, 0f);
                    if(isHit)
                    {
                        return movePoint;
                    }
                    if(stepCanMove == 4)
                    {
                        return movePoint;
                    }
                }
            }
            canMove = false;
            if (direction == "Vertical")
            {

            }

        }
        return movePoint;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tile"))
        {
            /*if(amount == other.gameObject.)*/
        }
    }
    
}
