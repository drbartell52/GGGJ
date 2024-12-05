using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMovement : MonoBehaviour
{
    private JellyBaby _myJB;

    public bool check;
    
    // Start is called before the first frame update
    void Start()
    {
        _myJB = GetComponent<JellyBaby>();
    }

    // Update is called once per frame
    void Update()
    {
        if (check == true)
        {
            var friend = _myJB.GetFriend();
            this.gameObject.transform.position = friend.friendHugPos.position;
            this.gameObject.transform.rotation = friend.friendHugPos.rotation;
            //friend.gameObject.pa
        }
    }
}
