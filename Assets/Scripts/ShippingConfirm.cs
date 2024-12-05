using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingConfirm : MonoBehaviour
{
    public Shipping shipping;
    
    
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
        if (other.CompareTag("Player") && shipping.GetShippingBool() == true)
        {
            Destroy(shipping.GetJellyToShip());
            shipping.SetShippingBool(0);
        }
    }
}
