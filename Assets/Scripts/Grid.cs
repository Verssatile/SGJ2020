﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int rows;
    private int cols;

    private int[,] gridArray;

    private float cellSize;


    Vector3 gridOffset;

    public Grid(int rows, int cols, float cellSize, Vector3 gridOffset)
    {
        this.rows = rows;
        this.cols = cols;
        this.cellSize = cellSize;

        gridArray = new int[rows, cols];
        this.gridOffset = gridOffset;
    }

    public Vector3 GetWorldPosition(int row, int col)
    {
        return new Vector3(row*cellSize,0,col*cellSize) + gridOffset;
    }
    public void SetValue(int x, int y, int value)
    {
        if (x < 0 || x >= rows || y < 0 || y >= cols)
        {
            Debug.Log("Error, row or col out of range!");
            return;
        }
        gridArray[x, y] = value;
    }
    public void SetValue(Vector3 worldPos, int value)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        SetValue(x, y, value);
    }
    public void GetXY(Vector3 worldPos, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPos-gridOffset).x / cellSize);
        y = Mathf.FloorToInt((worldPos-gridOffset).z / cellSize);
    }
    public int GetValue(int x, int y)
    {
        if (x < 0 || x >= rows || y < 0 || y >= cols)
        {
            Debug.Log("Error, row or col out of range!");
            return -1;
        }
        return gridArray[x, y];
    }
   
}