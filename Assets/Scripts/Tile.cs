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
        movePoint.parent = null;
    }

    private void Update()
    {


            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                canMove = true;
            CheckNextMove("Horizontal");
            }


            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.localPosition + new Vector3(Input.GetAxisRaw("Vertical"), 0f, 0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, movePoint.position, moveSpeed * Time.deltaTime);


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
