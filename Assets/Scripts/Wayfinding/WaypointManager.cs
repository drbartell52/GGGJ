using System;
using System.Linq;
using UnityEngine;

namespace Wayfinding
{
    public class WaypointManager : MonoBehaviour
    {
        
        private Waypoint[] allWaypoints;
        public Waypoint current;
        public Waypoint target;

        private void Awake()
        {
            AssignWaypointsFromChildren();
            current = allWaypoints[0];
        }

        [ContextMenu("Get Waypoints in Children")]
        public void AssignWaypointsFromChildren()
        {
            allWaypoints = GetComponentsInChildren<Waypoint>();
        }
        
        public void InitializeOntoPath(Transform transform)
        {
            allWaypoints = allWaypoints.OrderBy(x => Vector3.Distance(x.GetPos(), transform.position)).ToArray();
            current = allWaypoints[0];

            int getClosestNeighborIndex = 1;
            while (!current.neighbours.Contains(allWaypoints[getClosestNeighborIndex]))
            {
                getClosestNeighborIndex++;
            }

            target = allWaypoints[getClosestNeighborIndex];
        }

        public void SetCurrent(Waypoint newCurrent)
        {
            current = newCurrent;
            if (!allWaypoints.Contains(newCurrent))
            {
                Debug.LogError("Can't move to waypoint, this waypoint is from a different path.");
            }
        }
        
        public void MoveToNewPath(Vector3 inputWorldDir, float t)
        {
            if (t > 0 && t < 1)
            {
                //should we tho?
                Debug.Log("Trying to move to new path but we aren't at a path end.");
            }
            Debug.Log("moovey tooey newey pathey");

        
            if (current.TryGetNeighbourInDirection(inputWorldDir, out var newTarget))
            {
                //move to new path
                if (Math.Abs(t - 1) < 0.1f)
                {
                    SetCurrent(target);
                    target = newTarget;
                }
                else
                {
                    target = newTarget;
                }
                t = 0;

            }
        }

        public void OnDrawGizmos()
        {
            foreach (var a in allWaypoints)
            {
                a.DrawGizmosToNeighbours();
            }
        }

        private void OnValidate()
        {
            AssignWaypointsFromChildren();
        }
    }
}