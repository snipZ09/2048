using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CellManager : MonoBehaviour
{
    public static CellManager instance;

    public GameObject grid;
    public Cell[] cells;
    public Tile tile;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
        
    }

    public void SpawnTileRandom()
    {
        var randomChange = Random.Range(0f, 1f);
        var randomCell = Random.Range(0, cells.Length);
        if(randomChange >= 0.3f)
        {
            var myNewTile = Instantiate(tile, cells[randomCell].transform.position, transform.rotation);
            myNewTile.transform.parent = gameObject.transform;
        }
        if(randomChange < 0.3f)
        {
            var myNewTile = Instantiate(tile, cells[randomCell].transform.position, transform.rotation);
            myNewTile.transform.parent = gameObject.transform;
            var randomCell1 = Random.Range(0, cells.Length);
            myNewTile = Instantiate(tile, cells[randomCell].transform.position, transform.rotation);
            myNewTile.transform.parent = gameObject.transform;
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
