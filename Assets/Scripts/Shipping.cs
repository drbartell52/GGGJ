using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipping : MonoBehaviour
{
    public bool ready2ship = false;
    public GameObject jelly2ship;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Placement"))
        {
            ready2ship = true;
            jelly2ship = other.gameObject;
        }
    }

    public void SetShippingBool(int binaryValue)
    {
        if (binaryValue == 0)
        {
            ready2ship = false;
        }
        else if (binaryValue == 1)
        {
            ready2ship = true;
        }
        else
        {
            return;
        }
    }

    public bool GetShippingBool()
    {
        return ready2ship;
    }

    public GameObject GetJellyToShip()
    {
        return jelly2ship;
    }
}
