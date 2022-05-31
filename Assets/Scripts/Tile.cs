using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tile : MonoBehaviour
{
    public static Tile instance;
    public int value
    {
        get => _value;
        set
        {
            valueText.text = value.ToString();
            Debug.Log("value:" + value);
            _value = value;
        }
    }
    public Text valueText;
    public float moveSpeed;
    public LayerMask whatStopsMovement;
    public int xOffset, yOffset;
    public int stepCanMove;
    int xMoveTo, yMoveTo;

    public int winCondition = 64;

    int _value;
    public bool canMove;

    public Vector2 currentPos;
    public TileManager tManager;


    private void TestMoveRight()
    {
        //lay index thang ben phai cai nay
        //neu no o ngoai cung thi thoi
        Vector2 newPos = currentPos;
        int columnCount = 4;
        newPos.x = currentPos.x + 1 > columnCount ? columnCount : currentPos.x + 1;
        //neu vi tri moi nam ngoai mang thi bo qua
        if (newPos.x >= TileManager.instance.tiles.GetLength(0) || newPos.y >= TileManager.instance.tiles.GetLength(1))
        {
            Debug.Log("loi logic tim vi tri moi");
            return;
        }

        Tile goInTargetCell = TileManager.instance.tiles[(int)newPos.x, (int)newPos.y];

        //neu co object thi tinh, neu khong co thi move luon



    }


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        canMove = true;
    }


    private void Update()
    {
        //Tìm tile đang ở hàng nào
        // currentPos.y = (float)this.GetComponentInParent<Cell>().yIndex;
        //Tìm tile đang ở cột nào
        // currentPos.x = (float)this.GetComponentInParent<Cell>().xIndex;
        //Debug.Log(currentPos.x + " - " + currentPos.y);

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    MoveRight(yOffset);
        //}

        //valueText.text = "" + value;
    }

    public void MoveRight(int row)
    {
        this.xMoveTo = TileManager.instance.maxX;
        //Di chuyển nhưng chưa có nhập lại được
        while (transform.position != TileManager.instance.tiles[row, xMoveTo].transform.position)
        {
            if (TileManager.instance.tiles[row, xMoveTo].GetComponent<Cell>().hasTile)
            {
                if (xMoveTo == TileManager.instance.minX)
                {
                    return;
                }
                xMoveTo--;
            }
            else
            {
                transform.position = TileManager.instance.tiles[row, xMoveTo].transform.position;
                transform.parent = TileManager.instance.tiles[row, xMoveTo].transform;
            }
        }
    }

    public void MoveLeft()
    {
        while (canMove)
        {
            Debug.Log("Move left");
            Vector2 newPos = GetNewPos(3);
            Debug.Log("new pos:" + newPos);
            Debug.Log("currentPos:" + currentPos);
            //neu vi tri moi nam ngoai mang thi bo qua
            if (newPos.x >= TileManager.instance.tiles.GetLength(0) || newPos.y >= TileManager.instance.tiles.GetLength(1))
            {
                Debug.Log("loi logic tim vi tri moi");
                return;
            }

            ProcessMove(newPos);
        }
    }

    public void MoveRight()
    {
        while (canMove)
        {
            Debug.Log("Move right");
            Vector2 newPos = GetNewPos(4);
            Debug.Log("new pos:" + newPos);
            Debug.Log("currentPos:" + currentPos);
            //neu vi tri moi nam ngoai mang thi bo qua
            if (newPos.x == -1 || newPos.y == -1 || newPos.x >= TileManager.instance.tiles.GetLength(0) || newPos.y >= TileManager.instance.tiles.GetLength(1))
            {
                Debug.Log("loi logic tim vi tri moi");
                canMove = false;
                return;
            }
            ProcessMove(newPos);
        }
    }
    public void MoveUp()
    {
        while (canMove)
        {
            Debug.Log("Move up");
            Vector2 newPos = GetNewPos(1);
            Debug.Log("new pos:" + newPos);
            Debug.Log("currentPos:" + currentPos);
            //neu vi tri moi nam ngoai mang thi bo qua
            if (newPos.x < 0 || newPos.y < 0 || newPos.x >= TileManager.instance.tiles.GetLength(0) || newPos.y >= TileManager.instance.tiles.GetLength(1))
            {
                Debug.Log("loi logic tim vi tri moi");
                return;
            }
            ProcessMove(newPos);
        }
    }
    public void MoveDown()
    {
        while (canMove)
        {
            Debug.Log("Move up");
            Vector2 newPos = GetNewPos(2);
            Debug.Log("new pos:" + newPos);
            Debug.Log("currentPos:" + currentPos);
            //neu vi tri moi nam ngoai mang thi bo qua
            if (newPos.x < 0 || newPos.y < 0 || newPos.x >= TileManager.instance.tiles.GetLength(0) || newPos.y >= TileManager.instance.tiles.GetLength(1))
            {
                Debug.Log("loi logic tim vi tri moi");
                return;
            }
            ProcessMove(newPos);
        }
    }
    //1: up 2:down 3:left 4:right
    private Vector2 GetNewPos(int direction)
    {
        Vector2 newPos = currentPos;
        switch (direction)
        {
            case 1:
                newPos.y = currentPos.y;
                newPos.x = currentPos.x - 1 < 0 ? 0 : currentPos.x - 1;
                return newPos;

            case 2:
                newPos.y = currentPos.y;
                newPos.x = currentPos.x + 1 > tManager.rowCount ? tManager.rowCount : currentPos.x + 1;
                return newPos;
            case 3:
                newPos.x = currentPos.x;
                newPos.y = currentPos.y - 1 < 0 ? 0 : currentPos.y - 1;
                return newPos;
            case 4:
                newPos.x = currentPos.x;
                newPos.y = currentPos.y + 1 > tManager.columnCount ? tManager.columnCount : currentPos.y + 1;
                return newPos;

            default:
                return Vector2.one * -1;
        }
    }
    private void ProcessMove(Vector2 newPos)
    {
        Tile goInTargetCell = tManager.tiles[(int)newPos.x, (int)newPos.y];
        if (goInTargetCell == null)
        {
            //nếu vị trí newPos không có tile thì di chuyển vô đó và vị trí cũ ở trong mảng 2 chiều biến thành null
            Debug.Log("goInTargetCell ==null");

            tManager.tiles[(int)newPos.x, (int)newPos.y] = this;
            tManager.tiles[(int)currentPos.x, (int)currentPos.y] = null;
            transform.localPosition = tManager.positions[(int)newPos.x, (int)newPos.y];
        }
        else
        {
            //nếu vị trí newPos có tile
            Debug.Log("goInTargetCell !=null");
            //TODO: i am here
            //kiểm tra goInTargetCell có phải chính bản thân nó không
            if(this.gameObject == goInTargetCell.gameObject)
            {
                Debug.Log("Đụng chính mình bỏ qua");
                canMove = false;

            }
            //kiểm tra có bằng value của goInTargetCell không
            else if(this.value == goInTargetCell.value)
            {
                goInTargetCell.value += goInTargetCell.value;
                if(goInTargetCell.value == winCondition)
                {
                    tManager.Check2048();
                }
                //tManager.tiles[(int)currentPos.x, (int)currentPos.y] = null;
                //Destroy(this.gameObject);
                canMove = false;
                GameController.instance.score += 1;
                tManager.DeleteTile(this.currentPos);
            }
            else
            {
                canMove = false;
                tManager.CheckTileLost();
                return;
            }
        }
        currentPos = newPos;
    }



    public void MoveUp(int column)
    {
        this.yMoveTo = TileManager.instance.minY;

        while (transform.position != TileManager.instance.tiles[yMoveTo, column].transform.position)
        {
            if (TileManager.instance.tiles[yMoveTo, column].GetComponent<Cell>().hasTile)
            {
                if (yMoveTo == TileManager.instance.maxY)
                {
                    return;
                }
                yMoveTo++;
            }
            else
            {
                transform.position = TileManager.instance.tiles[yMoveTo, column].transform.position;
                transform.parent = TileManager.instance.tiles[yMoveTo, column].transform;
            }

        }
    }

    public void MoveDown(int column)
    {
        this.yMoveTo = TileManager.instance.maxY;

        while (transform.position != TileManager.instance.tiles[yMoveTo, column].transform.position)
        {
            if (TileManager.instance.tiles[yMoveTo, column].GetComponent<Cell>().hasTile)
            {
                if (yMoveTo == TileManager.instance.minY)
                {
                    return;
                }
                yMoveTo--;
            }
            else
            {
                transform.position = TileManager.instance.tiles[yMoveTo, column].transform.position;
                transform.parent = TileManager.instance.tiles[yMoveTo, column].transform;
            }

        }
    }





}
