using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;
    public Cell[] allCells;
    public Tile[] allTiles = new Tile[16];
    public Tile[,] tiles = new Tile[4, 4];
    public Tile tilePrefab;

    public Vector2[,] positions = new Vector2[4, 4];

    public int minX = 0, maxX = 3, minY = 0, maxY = 3;

    public int columnCount = 4;
    public int rowCount = 4;

    private void Awake()
    {
        instance = this;
    }

    //tao mang vector2 tu 1 danh sach vi tri
    private void CreatePostion()
    {
        for (int i = 0; i < allCells.Length; i++)
        {
            int firstDimensionIndex = i / 4;
            int secondDimensionIndex = i % columnCount;
            //Debug.Log("secondDimensionIndex:" + secondDimensionIndex);
            
            positions[firstDimensionIndex, secondDimensionIndex] = allCells[i].transform.localPosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatePostion();
        //Test hàm tạo tile ở vị trí vector2
        CreateTile(new Vector2(1, 1), 2);
        //Test hàm xóa tile ở vị trí vector2
        //DeleteTile(new Vector2(1, 0));

    }

    // Update is called once per frame
    void Update()
    {
        AddIndexToCell();
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.R))
        {
            SpawnTileRandom();
        }
#endif
        if (Input.GetKeyDown(KeyCode.D))
        {
            CallMoveRight();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CallMoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            CallMoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CallMoveDown();
        }

    }

    private void CallMoveRight()
    {
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = tiles.GetLength(1) - 1; j >= 0; j--)
            {
                Tile tile = tiles[i, j];
                if (tile != null)
                {
                    Debug.Log("call move right: " + i + "||" + j);
                    tile.MoveRight();
                    
                }
            }
        }
    }

    private void CallMoveLeft()
    {
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                Tile tile = tiles[i, j];
                if (tile != null)
                {
                    Debug.Log("call move left");
                    tile.MoveLeft();
                }
            }
        }
    }

    private void CallMoveUp()
    {
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                Tile tile = tiles[i, j];
                if (tile != null)
                {
                    Debug.Log("call move left");
                    tile.MoveUp();
                }
            }
        }
    }

    private void CallMoveDown()
    {
        for (int i = tiles.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                Tile tile = tiles[i, j];
                if (tile != null)
                {
                    Debug.Log("call move left");
                    tile.MoveDown();
                }
            }
        }
    }

    public void SpawnTileRandom()
    {
        var randomChange = Random.Range(0f, 1f);
        int randomColumn = Mathf.RoundToInt(Random.Range(0, 4));
        int randomRow = Mathf.RoundToInt(Random.Range(0, 4));
        if (tiles[randomColumn, randomRow] != null)
        {
            Debug.Log("Cell " + randomColumn + " - " + randomRow + " has tile");
            SpawnTileRandom();
            return;
        }
        int randomValue;
        if (randomChange < 0.85f)
        {
            randomValue = 2;
        }
        else
        {
            randomValue = 4;
        }
        CreateTile(new Vector2(randomColumn, randomRow), randomValue);
    }

    public void CreateTile(Vector2 pos, int value)
    {
        //int count = CountIndex(pos);
        Tile myNewTile = Instantiate(tilePrefab, transform);
        //allTiles[count] = myNewTile;
        myNewTile.transform.localPosition = positions[(int)pos.x, (int)pos.y];
        myNewTile.tManager = this;
        myNewTile.currentPos = pos;
        myNewTile.value = value;
        tiles[(int)pos.x, (int)pos.y] = myNewTile;
    }

    public void DeleteTile(Vector2 pos)
    {
        int count = CountIndex(pos);
        Debug.Log("Đã xóa tile ở vị trí x: " + pos.x + " y: " + pos.y + " index: " + count);        
        Destroy(tiles[(int)pos.x, (int)pos.y].gameObject);
        tiles[(int)pos.x, (int)pos.y] = null;
    }

    public int CountIndex(Vector2 pos)
    {
        int count = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == (int)pos.x && j == (int)pos.y)
                {
                    return count;
                }
                count++;
            }
        }
        return count;
    }

    public void AddIndexToCell()
    {
        int count = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                allCells[count].yIndex = i;
                allCells[count].xIndex = j;
                count++;
            }
        }
    }

    public void CheckRow(int row, int direction)
    {
        int count = 0;
        int i = (direction > 0) ? maxX : minX;
        int condition = (direction > 0) ? minX : maxX;

        while (count < 4)
        {
            if (tiles[row, i].transform.childCount != 0)
            {
                tiles[row, i].GetComponentInChildren<Tile>().MoveRight(row);
            }
            count++;

            i = i > condition ? i-- : i++;
        }

    }

    public void Combine(Tile a, Tile b)
    {
        //GameObject myNewTile = Instantiate(tileToSpawn, a.transform);
        //myNewTile.GetComponent<Tile>().value = a.value * 2;
    }
}
