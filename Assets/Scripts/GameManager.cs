using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public bool babyDrop;
    public bool toShip = false;

    public int ctr;
    public int moralityScore;

    public GameObject PDA;

    private ObjectPooler _op;
    private MultiListPooler _mlp;

    private List<String> pdaText = new List<string>() {"green", "multi-color", "hat"};
    
    
    //private DisableMetaPopup dmp;
    
    
    private void Awake()
    {
        //dmp = GetComponent<DisableMetaPopup>();
        //dmp.DisablePopup();
        _op = GetComponent<ObjectPooler>();
        _mlp = GetComponent<MultiListPooler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        babyDrop = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (babyDrop == true)
        {
            //_op.MakeNumAvailable(ctr);

            var randValue = Random.Range(0, 2);
            
            _mlp.MakeNumAvailable(ctr, randValue);
            
            
            ctr += 1;
            babyDrop = false;
        }

        if (ctr == 5 && toShip == false)
        {
            var randValue = Random.Range(0, 2);
            PDA.GetComponentInChildren<TextMeshPro>().text = pdaText[randValue];
            toShip = true;
        }
    }

    public void PlacedBaby(Placeable placedBaby)
    {
        //babyDrop = true;
        
        //_op.MakeNumAvailable(ctr);
        
        var randValue = Random.Range(0, 2);
        
        _mlp.MakeNumAvailable(ctr, randValue);
        
        ctr += 1;
        
        Debug.Log("baby placed!");
    }
}
