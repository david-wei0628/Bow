using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWallInstan : MonoBehaviour
{
    public GameObject Door;
    public GameObject Wall;


    public void DoorInstanEven()
    {

    }

    public void WallInstanEven(Vector3 OnPos, string Direc)
    {
        GameObject WallObject;
        WallObject = Instantiate(Wall, OnPos, Quaternion.identity, this.gameObject.transform);
        switch (Direc)
        {
            case "F":
                print("F");
                WallObject.transform.position += new Vector3(0, 0, 4);
                //WallObject.transform.localEulerAngles = Vector3.zero;
                //WallObject.transform.position += new Vector3(0, 0, 0);
                break;
            case "B":
                WallObject.transform.position += new Vector3(0, 0, -4);
                //WallObject.transform.localEulerAngles = Vector3.zero;
                //WallObject.transform.position += new Vector3(0, 0, 0);
                break;
            case "L":
                //print("L");
                WallObject.transform.position += new Vector3(-4, 0, 0);
                //WallObject.transform.localEulerAngles = Vector3.zero;
                //WallObject.transform.position += new Vector3(0, 0, 0);
                break;
            case "R":
                //print("R");
                WallObject.transform.position += new Vector3(4, 0, 0);
                //WallObject.transform.localEulerAngles = Vector3.zero;
                //WallObject.transform.position += new Vector3(0, 0, 0);
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
