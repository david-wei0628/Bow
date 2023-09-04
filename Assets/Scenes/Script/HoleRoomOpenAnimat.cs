using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleRoomOpenAnimat : MonoBehaviour
{
    Animator HoleRoomAnimal;
    // Start is called before the first frame update
    void Start()
    {
        HoleRoomAnimal = GetComponent<Animator>();
        if (/*Input.GetKeyDown(KeyCode.Space) &&*/ this.tag == "Room")
        {
            HoleRoomAnimal.SetTrigger("Create");
        }
        if (/*Input.GetKeyDown(KeyCode.A) &&*/ this.tag == "Road")
        {
            HoleRoomAnimal.SetTrigger("RoadDown");
        }
    }
}
