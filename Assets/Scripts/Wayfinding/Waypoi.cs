using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[Serializable]
public class Waypoint: MonoBehaviour
{
    public List<Waypoint> neighbours;

    
    public Waypoint GetNeighbourInDirection(Vector3 dir, float angleThreshold)
    {
        Waypoint closest = null;

        float smallestAngle = Mathf.Infinity;
        
        foreach (var waypoint in neighbours)
        {
            var wayDirection = (waypoint.GetPos() - GetPos()).normalized;
            var angle = Vector3.Angle(wayDirection, dir);

            if (angle < smallestAngle && angle < angleThreshold)
            {
                smallestAngle = angle;
                closest = waypoint;
            }
        }

        return closest;
    }

    public bool TryGetNeighbourInDirection(Vector3 direction, out Waypoint neighbour)
    {
        neighbour = GetNeighbourInDirection(direction, 90);
        
        return neighbour != null;
    }
    
    
    
    
    public Vector3 GetPos()
    {
        return transform.position;
    }


    public void DrawGizmosToNeighbours()
    {
        foreach (var waypoint in neighbours)
        {
            Debug.DrawLine(waypoint.GetPos(), GetPos(), Color.yellow);
        }
    }
}
