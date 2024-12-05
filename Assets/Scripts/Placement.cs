using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public GameManager _gm;  
    
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
        var placeable = other.GetComponent<Placeable>();
        if (placeable != null)
        {
            if (placeable.CanPlace(this))
            {
                other.gameObject.transform.position = this.transform.position;
                other.gameObject.transform.rotation = this.transform.rotation;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                _gm.PlacedBaby(placeable);
                
                placeable.OnPlaced();
            }
        }
    }
}
