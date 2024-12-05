using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiListPooler : MonoBehaviour
{

    public List<List<GameObject>> unavailablePools;
    public List<List<GameObject>> availablePools;
    
    public List<GameObject> availablePool1;
    private List<GameObject> unavailablePool1;
    public List<GameObject> availablePool2;
    private List<GameObject> unavailablePool2;
    public List<GameObject> availablePool3;
    private List<GameObject> unavailablePool3;

    public List<GameObject> objectPrefabs;
    
    private Vector3 saveLocation;
    private Quaternion saveRotation;

    public GameObject objectPrefab;
    public GameObject objectPrefab2;
    public GameObject objectPrefab3;
    
    public Transform objectSpawnLocation;
    public int amount;
    

    private void Awake()
    {
        unavailablePools = new List<List<GameObject>>();
        availablePools = new List<List<GameObject>>();

        
        //Creates separate lists for unavailable and available game objects
        availablePool1 = new List<GameObject>();
        unavailablePool1 = new List<GameObject>();
        availablePool2 = new List<GameObject>();
        unavailablePool2 = new List<GameObject>();
        availablePool3 = new List<GameObject>();
        unavailablePool3 = new List<GameObject>();
        
        
        unavailablePools.Add(unavailablePool1);
        unavailablePools.Add(unavailablePool2);
        unavailablePools.Add(unavailablePool3);
        availablePools.Add(availablePool1);
        availablePools.Add(availablePool2);
        availablePools.Add(availablePool3);

        objectPrefabs = new List<GameObject>();
        objectPrefabs.Add(objectPrefab);
        objectPrefabs.Add(objectPrefab2);
        objectPrefabs.Add(objectPrefab3);
    }

    private void Start()
    {
        GameObject birth;
        //Temporary variable for instantiated game object
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < amount; j++)
            {
                birth = Instantiate(objectPrefabs[i], objectSpawnLocation);
                birth.SetActive(false);
                unavailablePools[i].Add(birth);
            }
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
            change = unavailablePool1[i];
            availablePool1.Add(change);
            change.SetActive(true);
            //Also changes the objects to active
        }
    }
    
    public void MakeNumAvailable(int num, int index)
    {
        GameObject change;
        //for (int i = num; i <= num; i++)
        //{
            //Moves an object marked at the index 'num' of the unavailable pool to the available pool
            if (num < amount)
            {
                //Function only works if the num is less than the max items, 'amount' 
                Debug.Log(index);
                change = unavailablePools[index][num];
                availablePools[index].Add(change);
                change.SetActive(true);
                //Also changes the object to active
            }
        //}
    }
    
    public void MakeAmntAvailable(int amnt)
    {
        GameObject change;
        for (int i = 0; i <= amnt; i++)
        {
            //Moves all objects up to the number 'amnt' from the unavailable pool to the available pool
            change = unavailablePool1[i];
            availablePool1.Add(change);
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
            death = unavailablePool1[i];
            death.transform.position = saveLocation;
            death.transform.rotation = saveRotation;
            //Resets the position and rotation of the game object
            death.SetActive(false);
            unavailablePool1.Add(death);
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
                death = availablePool1[i];
                death.transform.position = saveLocation;
                death.transform.rotation = saveRotation;
                //Resets the position and rotation of the game object
                death.SetActive(false);
                unavailablePool1.Add(death);
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
            death = availablePool1[i];
            death.transform.position = saveLocation;
            death.transform.rotation = saveRotation;
            //Resets the position and rotation of the game object
            death.SetActive(false);
            unavailablePool1.Add(death);
            //Also changes the object to inactive
        }
    }
    
    //pick randon color
    //pick random body part
}

