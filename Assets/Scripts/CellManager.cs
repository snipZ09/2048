using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CellManager : MonoBehaviour
{
    public static CellManager instance;

    public GameObject grid;
    public Cell[] allCells;
    public GameObject tileToSpawn;
    public int[,] cells = new int[4,4];
    public float minX, maxX, minY, maxY = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindMinMaxXY();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.R))
        {
            SpawnTileRandom();
        }
#endif
        CheckCellEmpty();

    }

    public void SpawnTileRandom()
    {
        
        var randomChange = Random.Range(0f, 1f);
        var randomCell = Random.Range(0, allCells.Length);
        if (allCells[randomCell].transform.childCount != 0)
        {
            Debug.Log("Cell " + randomCell + " has tile");
            SpawnTileRandom();
            return;
        }
        if(randomChange < 0.85f)
        {
            GameObject myNewTile = Instantiate(tileToSpawn, allCells[randomCell].transform);
        }
        else
        {
            GameObject myNewTile = Instantiate(tileToSpawn, allCells[randomCell].transform);
        }
    }

    public int[,] CheckCellEmpty()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; i < 4; i++)
            {
                if (allCells[i + j].transform.childCount != 0)
                {
                    cells[i, j] = 1;
                }
                else
                {
                    cells[i, j] = 0;
                }
            }
        }
        return cells;
    }

    public void FindMinMaxXY()
    {
        foreach (Cell cell in allCells)
        {
            bool smallX = cell.transform.position.x < minX;

            bool bigX = cell.transform.position.x > maxX;

            bool smallY = cell.transform.position.y < minY;

            bool bigY = cell.transform.position.y > maxY;


            minX = smallX ? cell.transform.position.x : minX;
            maxX = bigX ? cell.transform.position.x : maxX;
            minY = smallY ? cell.transform.position.y : minY;
            maxY = bigY ? cell.transform.position.y : maxY;
        }
    }





    //public Dictionary<int, int> GetMinYOnX(Transform[] transforms)
    //{
    //    Dictionary<int, int> mins = new Dictionary<int, int>();

    //    for (int i = 0; i < transforms.Length; i++)
    //    {
    //        var xInt = Mathf.RoundToInt(transforms[i].position.x);
    //        var yInt = Mathf.RoundToInt(transforms[i].position.y);

    //        int currentMin = 0;
    //        if (mins.TryGetValue(xInt, out currentMin))
    //        {
    //            if (yInt <= currentMin)
    //                mins[xInt] = yInt;
    //        }
    //        else
    //        {
    //            mins.Add(xInt, yInt);
    //        }


    //    }

    //    return mins;
    //}

}
