using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    //Color startColor = new Color(106, 27, 154, 255);
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;
    Waypoint searchCenter;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
 

    // Use this for initialization
    void Start () {
        LoadBlocks();
        ColorStartAndEnd();
        //Exploreneighbors();
        Pathfind();
	}

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;

            HaltIfEndFound();
            Exploreneighbors();
        }

        print("Finished pathfinding?");
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void Exploreneighbors()
    {
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int exploring = searchCenter.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(exploring);
            }
            catch
            {

            }
                
        }
    }

    private void QueueNewNeighbours(Vector2Int exploring)
    {
        Waypoint neighbour = grid[exploring];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
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