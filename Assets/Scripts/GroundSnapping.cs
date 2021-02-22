using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSnapping : MonoBehaviour
{
    public Vector3 gridSize = Vector3.one;
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying && this.transform.hasChanged)
        {
            SnapToRectGrid();
        }
    }

    private void SnapToRectGrid()
    {
        Vector3 position = new Vector3(
            (float) Math.Round(this.transform.position.x / gridSize.x) * gridSize.x,
            (float) Math.Round(this.transform.position.y / gridSize.y) * gridSize.y,
            (float) Math.Round(this.transform.position.z / gridSize.z) * gridSize.z
        );

        this.transform.position = new Vector3(position.x, position.y, position.z);
    }
}