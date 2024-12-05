using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<GameObject> availablePool;
    private List<GameObject> unavailablePool;
    private Vector3 saveLocation;
    private Quaternion saveRotation;

    public GameObject objectPrefab;
    public Transform objectSpawnLocation;
    public int amount;
    

    private void Awake()
    {
        //Creates separate lists for unavailable and available game objects
        availablePool = new List<GameObject>();
        unavailablePool = new List<GameObject>();
    }

    private void Start()
    {
        GameObject birth;
        //Temporary variable for instantiated game object
        for (int i = 0; i < amount; i++)
        {
            //Create number (determined by 'amount') of prefab game objects at location 'objectSpawnLocation'
            birth = Instantiate(objectPrefab, objectSpawnLocation);
            
            var meshes = birth.gameObject.GetComponentsInChildren<MeshRenderer>();
            
            
            
            foreach (var mesh in meshes)
            {
                mesh.material.color = Random.ColorHSV();
            }
            
            //birth.gameObject.GetComponentsInChildren<MeshRenderer>() = color;
            //Debug.Log(color.color);
            birth.SetActive(false);
            //All Instantiated objects are set to inactive
            unavailablePool.Add(birth);
            //Adds each object to the list 'unavailablePool'
        }

        saveLocation = objectSpawnLocation.position;
        saveRotation = Quaternion.identity;
        //Saves the location and rotation of the original game objects
    }

    public void MakeAvailable()
    {
        GameObject change;
        for (int i = 0; i < amount; i++)
        {
            //Moves all objects from the unavailable pool to the available pool
            change = unavailablePool[i];
            availablePool.Add(change);
            change.SetActive(true);
            //Also changes the objects to active
        }
    }
    
    public void MakeNumAvailable(int num)
    {
        GameObject change;
        for (int i = num; i <= num; i++)
        {
            //Moves an object marked at the index 'num' of the unavailable pool to the available pool
            if (num < amount)
            {
                //Function only works if the num is less than the max items, 'amount' 
                change = unavailablePool[i];
                availablePool.Add(change);
                change.SetActive(true);
                //Also changes the object to active
            }
        }
    }
    
    public void MakeAmntAvailable(int amnt)
    {
        GameObject change;
        for (int i = 0; i <= amnt; i++)
        {
            //Moves all objects up to the number 'amnt' from the unavailable pool to the available pool
            change = unavailablePool[i];
            availablePool.Add(change);
            change.SetActive(true);
            //Also changes the object to active
        }
    }

    public void MakeUnavailable()
    {
        GameObject death;
        for (int i = 0; i < amount; i++)
        {
            //Moves all objects from the unavailable pool to the available pool
            death = unavailablePool[i];
            death.transform.position = saveLocation;
            death.transform.rotation = saveRotation;
            //Resets the position and rotation of the game object
            death.SetActive(false);
            unavailablePool.Add(death);
            //Also changes the object to inactive
        }
    }

    public void MakeNumUnavailable(int num)
    {
        GameObject death;
        for (int i = num; i <= num; i++)
        {
            if (num < amount)
            {
                //Function only works if the num is less than the max items, 'amount' 
                death = availablePool[i];
                death.transform.position = saveLocation;
                death.transform.rotation = saveRotation;
                //Resets the position and rotation of the game object
                death.SetActive(false);
                unavailablePool.Add(death);
                //Also changes the object to inactive 
            }
        }
    }
    public void MakeAmntUnavailable(int amnt)
    {
        GameObject death;
        for (int i = 0; i <= amnt; i++)
        {
            //Moves all objects up to the number 'amnt' from the unavailable pool to the available pool
            death = availablePool[i];
            death.transform.position = saveLocation;
            death.transform.rotation = saveRotation;
            //Resets the position and rotation of the game object
            death.SetActive(false);
            unavailablePool.Add(death);
            //Also changes the object to inactive
        }
    }
}
