using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wayfinding;

public class WaypointMovement : MonoBehaviour
{

    public WaypointManager wpm;
    public GameObject controller;

    public float maxSpeed;//how fast we should move. 
    
    public float t = 0;
    public float currentPathSegmentDistance;
    
    //expression-bodied method/member
    private Vector3 inputDir;

    [SerializeField] public AnimationCurve curve;
    
    // Start is called before the first frame update
    void Start()
    {
        SnapToFirstWaypoint();
    }

    private void SnapToFirstWaypoint()
    {
        wpm.InitializeOntoPath(transform);
        t = 0;
        gameObject.transform.position = wpm.current.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //get input
        InputTick();
        
        
        if (wpm.target == null)
        {
            Debug.Log("wah");
            return;
        }

        if (wpm.current == null)
        {
            Debug.Log("wah wah");
            return;
        }

        //moveToNewPath at destination node
        if ((transform.position - wpm.target.transform.position).magnitude < 0.001f)
        {
            wpm.MoveToNewPath(inputDir, t);
            t = 0;
        }
        else if ((transform.position - wpm.current.transform.position).magnitude < 0.001f)        //move to new path back at start node
        {
            wpm.MoveToNewPath(inputDir, t);
            t = 0;
        }
        
        var pathDir = wpm.target.GetPos() - wpm.current.GetPos();
        float inputMultiplier = Vector3.Dot(inputDir, pathDir);//positive or negative
        if (t > 0.95f)//*currentDistance
        {
            float closeToPath = (t - 0.9f)*10f;
            inputMultiplier = Mathf.Lerp(inputMultiplier, 1, closeToPath);
        }
        
        currentPathSegmentDistance = Vector3.Distance(wpm.current.GetPos(), wpm.target.GetPos());
        
        //update movement
        t += Mathf.Clamp01((Time.deltaTime*inputMultiplier)/currentPathSegmentDistance);
        
        transform.position = Vector3.Lerp(wpm.current.GetPos(), wpm.target.GetPos(), t);
    }

    /// <summary>
    /// Updates InputDir.
    /// </summary>
    private void InputTick()
    {
        //todo: get input from the thing
        var controllerDirection = controller.transform.position;

        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputDir = new Vector3(0, 0, 1);
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            inputDir = new Vector3(0, 0, -1);

        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputDir = new Vector3(-1, 0, 0);

        } else if (Input.GetKey(KeyCode.RightArrow) )
        {
            inputDir = new Vector3(1, 0, 0);
        }
        else
        {
            inputDir = Vector3.zero;
        }

        
    }
    
    //todo: move this into manager
   
}
