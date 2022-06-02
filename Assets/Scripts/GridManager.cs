﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int _width, _height;
    [SerializeField] Cell _cellPrefab;

    [SerializeField] Transform _cam;
    private Dictionary<Vector2, Cell> _cell;

    public Dictionary<Vector2, Cell> dCell
    {
        get { return _cell; }
        set { _cell = dCell; }
    }

    public int width
    {
        get => _width;
        set
        {
            width = _width;
        }
    }

    public int height
    {
        get => _height;
        set
        {
            height = _height;
        }
    }

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        _cell = new Dictionary<Vector2, Cell>();
        for(int i = 0; i < _width; i++)
        {
            for(int j = 0; j < _height; j++)
            {
                var spawnedCell = Instantiate(_cellPrefab, new Vector2(i, j), Quaternion.identity);
                spawnedCell.name = $"Cell {i} {j}";
                var isOffset = (i % 2 == 0 && j % 2 != 0 || i % 2 != 0 && j % 2 == 0);
                spawnedCell.Init(isOffset);

                _cell[new Vector2(i, j)] = spawnedCell;
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

    public Cell GetCellAtPosition(Vector2 pos)
    {
        try
        {
            if (dCell.TryGetValue(pos, out var cell))
            {
                return cell;
            }
                
        }
        catch(MissingReferenceException e)
        {
            Debug.Log(e.Message);
        }
        return null;
    }
}
