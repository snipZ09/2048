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
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) < 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                } 
            }
            
            
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Vertical"), 0f, 0f), 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                } 
            }
        }

        
    }

    public void CheckNextMove(string direction)
    {
        while (canMove)
        {
            if(direction == "Horizontal")
            {
                movePoint.position += new Vector3(Input.GetAxisRaw(direction) * xOffset, 0f, 0f);
                while(Physics2D.OverlapCircle(movePoint.position, 0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw(direction) * xOffset, 0f, 0f);
                }
            }
            if(direction == "Vertical")
            {

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
