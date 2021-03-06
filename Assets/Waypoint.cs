﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;

    Vector2Int gridPos;

    const int gridSize = 10;

    // Use this for initialization
    void Start () {
		
	}

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        (Mathf.RoundToInt(transform.position.x / gridSize)),
        (Mathf.RoundToInt(transform.position.z / gridSize))
        );
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTopColor(Color color)
    {
        MeshRenderer topMesh = transform.Find("Top").GetComponent<MeshRenderer>();
        topMesh.material.color = color;
    }
}
