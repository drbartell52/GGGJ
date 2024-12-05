using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public GameObject controller;
    
    public List<Transform> choiceJuncs;
    
    private int juncIndex = 0;

    public float t;

    public bool moveCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        moveCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(controller.transform.rotation);
        
        if (moveCheck == true)
        {
            t += Time.deltaTime;
            
            transform.position = Vector3.Lerp(transform.position, choiceJuncs[juncIndex].position, t);

            if (transform.position == choiceJuncs[juncIndex].position)
            {
                t = 0;
                moveCheck = false;
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && moveCheck == false)
        {
            juncIndex += 1;
            //transform.position = choiceJuncs[juncIndex].position;

            moveCheck = true;
            //Vector3.MoveTowards(this.transform.position, choiceJuncs[juncIndex].position, 5);
        }
        
        if (controller.transform.rotation.x <= -.3 && moveCheck == false)
        {
            juncIndex += 1;
            //transform.position = choiceJuncs[juncIndex].position;

            moveCheck = true;
            //Vector3.MoveTowards(this.transform.position, choiceJuncs[juncIndex].position, 5);
        }

        if (controller.transform.rotation.x >= .3 && moveCheck == false)
        {
            juncIndex -= 1;
            //transform.position = choiceJuncs[juncIndex].position;
            //Vector3.MoveTowards(this.transform.position, choiceJuncs[juncIndex].position, 5);

            moveCheck = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && moveCheck == false)
        {
            juncIndex -= 1;
            //transform.position = choiceJuncs[juncIndex].position;
            //Vector3.MoveTowards(this.transform.position, choiceJuncs[juncIndex].position, 5);

            moveCheck = true;
        }
    }

    private void StartMove()
    {
        
    }
}
