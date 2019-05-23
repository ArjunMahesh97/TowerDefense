using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    //Color startColor = new Color(106, 27, 154, 255);
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    // Use this for initialization
    void Start () {
        LoadBlocks();
        ColorStartAndEnd();
	}

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            { 
                Debug.LogWarning("Overlapping" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
                //waypoint.SetTopColor(startColor);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
