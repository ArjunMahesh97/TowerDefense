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

        if (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from: " + searchCenter);
            searchCenter.isExplored = true;

            HaltIfEndFound(searchCenter);
            Exploreneighbors(searchCenter);
        }

        print("Finished pathfinding?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            Debug.Log('a');
            isRunning = false;
        }
    }

    private void Exploreneighbors(Waypoint from)
    {
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int exploring = from.GetGridPos() + direction;
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
        if (neighbour.isExplored)
        {

        }
        else
        {
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            print("Queueing " + neighbour);
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
