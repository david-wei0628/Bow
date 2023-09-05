using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWallInstan : MonoBehaviour
{
    public GameObject Door;
    public GameObject Wall;
    GameObject DoorROWallGroup;

    public void DoorInstanEven(Transform OnPos, string Direc)
    {
        DoorROWallGroup = GameObject.Find("DoorORWall");
        GameObject WallObject;
        //WallObject = Instantiate(Wall, OnPos.position, Quaternion.identity/*, this.gameObject.transform*/);
        WallObject = Instantiate(Door, OnPos.position, Quaternion.identity, DoorROWallGroup.transform);
        switch (Direc)
        {
            case "F":
                WallObject.transform.position += new Vector3(0, 0.1f, 4);
                WallObject.transform.localEulerAngles = Vector3.up * 180 /*+ OnPos.localEulerAngles*/;
                break;
            case "B":
                WallObject.transform.position += new Vector3(0, 0.1f, -4);
                WallObject.transform.localEulerAngles = Vector3.zero /*+ OnPos.localEulerAngles*/;
                break;
            case "L":
                WallObject.transform.position += new Vector3(-4, 0.1f, 0);
                WallObject.transform.localEulerAngles = Vector3.up * 90 /*+ OnPos.localEulerAngles*/;
                break;
            case "R":
                WallObject.transform.position += new Vector3(4, 0.1f, 0);
                WallObject.transform.localEulerAngles = Vector3.down * 90 /*+ OnPos.localEulerAngles*/;
                break;
        }
    }

    public void WallInstanEven(Transform OnPos, string Direc)
    {
        DoorROWallGroup = GameObject.Find("DoorORWall");
        GameObject WallObject;
        //WallObject = Instantiate(Wall, OnPos.position, Quaternion.identity/*, this.gameObject.transform*/);
        WallObject = Instantiate(Wall, OnPos.position, Quaternion.identity, DoorROWallGroup.transform);
        switch (Direc)
        {
            case "F":
                WallObject.transform.position += new Vector3(0, 0.1f, 4);
                WallObject.transform.localEulerAngles = Vector3.up*180 /*+ OnPos.localEulerAngles*/;
                break;
            case "B":
                WallObject.transform.position += new Vector3(0, 0.1f, -4);
                WallObject.transform.localEulerAngles = Vector3.zero /*+ OnPos.localEulerAngles*/;
                break;
            case "L":
                WallObject.transform.position += new Vector3(-4, 0.1f, 0);
                WallObject.transform.localEulerAngles = Vector3.up * 90 /*+ OnPos.localEulerAngles*/;
                break;
            case "R":
                WallObject.transform.position += new Vector3(4, 0.1f, 0);
                WallObject.transform.localEulerAngles = Vector3.down * 90 /*+ OnPos.localEulerAngles*/;
                break;
        }
    }

    void DoorOpen()
    {

    }

    void DoorClose()
    {

    }
}
