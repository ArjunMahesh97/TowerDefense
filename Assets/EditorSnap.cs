using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorSnap : MonoBehaviour {

    [ExecuteInEditMode]

    private void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / 10f) * 10f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10f) * 10f;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
