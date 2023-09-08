using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (this.transform.GetChild(0).transform.position.y == 0)
        {
            //this.gameObject.GetComponent<HoleRoomGenerate>().DooeWall();
            Destroy(this.gameObject.GetComponent<Other>());
        }
    }

}
