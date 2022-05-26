using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public static CellManager instance;

    public Cell[] cells;

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
        //Transform[] transforms = new Transform[cells.Length];
        //for(int i = 0; i < cells.Length; i++)
        //{
        //    transforms[i] = cells[i].transform;
        //}

        //foreach (var item in GetMaxXOnY(transforms))
        //{
        //    Debug.Log(item.Key + "\t" + item.Value);
        //}
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

    //public Dictionary<int, int> GetMaxYOnX(Transform[] transforms)
    //{
    //    Dictionary<int, int> maxs = new Dictionary<int, int>();

    //    for (int i = 0; i < transforms.Length; i++)
    //    {
    //        var xInt = Mathf.RoundToInt(transforms[i].position.x);
    //        var yInt = Mathf.RoundToInt(transforms[i].position.y);

    //        int currentMax = 0;
    //        if (maxs.TryGetValue(xInt, out currentMax))
    //        {
    //            if (yInt > currentMax)
    //                maxs[xInt] = yInt;
    //        }
    //        else
    //        {
    //            maxs.Add(xInt, yInt);
    //        }


    //    }
    //    return maxs;
    //}
    //public Dictionary<int, int> GetMinXOnY(Transform[] transforms)
    //{
    //    Dictionary<int, int> mins = new Dictionary<int, int>();

    //    for (int i = 0; i < transforms.Length; i++)
    //    {
    //        var xInt = Mathf.RoundToInt(transforms[i].position.x);
    //        var yInt = Mathf.RoundToInt(transforms[i].position.y);

    //        int currentMax = 0;
    //        if (mins.TryGetValue(yInt, out currentMax))
    //        {
    //            if (xInt <= currentMax)
    //                mins[yInt] = xInt;
    //        }
    //        else
    //        {
    //            mins.Add(yInt, xInt);
    //        }


    //    }
    //    return mins;
    //}

    //public Dictionary<int, int> GetMaxXOnY(Transform[] transforms)
    //{
    //    Dictionary<int, int> maxs = new Dictionary<int, int>();

    //    for (int i = 0; i < transforms.Length; i++)
    //    {
    //        var xInt = Mathf.RoundToInt(transforms[i].position.x);
    //        var yInt = Mathf.RoundToInt(transforms[i].position.y);

    //        int currentMax = 0;
    //        if (maxs.TryGetValue(yInt, out currentMax))
    //        {
    //            if (xInt > currentMax)
    //                maxs[yInt] = xInt;
    //        }
    //        else
    //        {
    //            maxs.Add(yInt, xInt);
    //        }


    //    }
    //    return maxs;
    //}

}
