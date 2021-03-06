﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDisplay : MonoBehaviour
{
    int rows = 8;
    int cols = 8;
    float cellSize = 1f;
    Vector3 offset;
    public Grid grid;
    Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
        offset = new Vector3(-3.5f,0,-3.5f);
        grid = new Grid(cols,rows,cellSize, offset);   
    }
}
