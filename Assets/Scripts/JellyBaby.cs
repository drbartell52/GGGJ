using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Properties;
using UnityEngine;

public class JellyBaby : MonoBehaviour
{
    public List<JellyBaby> otherJellies;
    public Transform friendHugPos;

    [Header("Property Setup")]
    [SerializeReference] //huntermagik
    public List<JellyProperty> BaseProperties;
    public List<JellyProperty> ArmProperties;
    public List<JellyProperty> LegProperties;

    [Header("Config Junk")]

    public MeshRenderer[] ArmsMeshes;
    public MeshRenderer[] LegMeshes;
    [HideInInspector]
    public MeshRenderer[] Meshes;
    public JellyBaby GetFriend()
    {
        var friend = otherJellies[0];
        

        return friend;
    }

    private void Awake()
    {
        Meshes = GetComponentsInChildren<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var jellyProperty in BaseProperties)
        {
            jellyProperty.Apply(this);
        }
        foreach (var jellyProperty in ArmProperties)
        {
            jellyProperty.Apply(this, JellyBodyPart.Arms);
        }
        foreach (var jellyProperty in LegProperties)
        {
            jellyProperty.Apply(this, JellyBodyPart.Legs);
        }
    }

    public void AddProperty(JellyProperty prop, JellyBodyPart bodyPart)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Vector3 GetPos()
    {
        return transform.position;
    }
}
