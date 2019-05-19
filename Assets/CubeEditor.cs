using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {

    const int gridSize = 10;

    TextMesh textMesh;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
        transform.name = snapPos.x / gridSize + "," + snapPos.z / gridSize;
    }
}
