using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width, height;
    public Cell cellPrefab;
    public SpriteRenderer boardPrefab;
    public Transform cam;
    public Dictionary<Vector2, Cell> dCell;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        dCell = new Dictionary<Vector2, Cell>();
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                var spawnedCell = Instantiate(cellPrefab, new Vector2(x, y), Quaternion.identity);
                spawnedCell.name = $"Cell {x} {y}";
                var isOffset = (x % 2 != y % 2);
                spawnedCell.Init(isOffset);

                dCell[new Vector2(x, y)] = spawnedCell;
            }
        }

        //-0.5f vì các cell đều ở giữa mỗi Vector. VD: sprite mỗi cell ở vị trí 0,0 thì nó trải dài từ -0.5 đến 0.5 ở x
        var center = new Vector2((float)width / 2 - 0.5f, (float)height / 2 - 0.5f);
        cam.transform.position = new Vector3 (center.x, center.y, -10);
        var board = Instantiate(boardPrefab, center, Quaternion.identity);
        board.size = new Vector2(width, height);


    }

    public Cell GetCellAtPosition(Vector2 pos)
    {
        if (dCell.TryGetValue(pos, out var cell))
        {
            return cell;
        }    
        return null;
    }   
}
