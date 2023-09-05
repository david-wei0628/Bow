using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleRoomGenerate : MonoBehaviour
{
    public List<GameObject> HoleRoomList;
    [SerializeField]
    private bool[] AroundBool = new bool[4];
    //0->Forward|1->Back|2->Left|3->Right
    bool[] NextAroundBool = new bool[4];

    private GameObject Plane;

    //Vector3 F = new Vector3(0, 0, 10);
    Vector3 F = Vector3.forward * 10;
    //Vector3 D = new Vector3(0, 0, -10);
    Vector3 B = Vector3.back * 10;
    //Vector3 L = new Vector3(-10, 0, 0);
    Vector3 L = Vector3.left * 10;
    //Vector3 R = new Vector3(10, 0, 0);
    Vector3 R = Vector3.right * 10;

    void Start() => ExporTo();
    //{
    //    //OnAroundBool = AroundBool;
    //    ExporTo();
    //}

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    HoleRoomBuilder();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "F");
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "B"); ;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "L"); ;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "R"); ;
        //}

    }

    private void FixedUpdate()
    {

    }

    /// <summary>
    /// ¶¡¶Z10
    /// </summary>
    public void HoleRoomBuilder()
    {
        Vector3 NewPos = this.transform.position;
        GameObject GrapGameObject = gameObject.transform.parent.gameObject;

        if (NextAroundBool[0])
        {
            if (AroundRoom(F))
            {
                RangeRoom(NewPos + F, "F", GrapGameObject);
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "F");
            }
            else
            {
                Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "F");
            }
        }

        if (NextAroundBool[1])
        {
            if (AroundRoom(B))
            {
                RangeRoom(NewPos + B, "B", GrapGameObject);
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "B");
            }
            else
            {
                Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "B");
            }
        }

        if (NextAroundBool[2])
        {
            if (AroundRoom(L))
            {
                RangeRoom(NewPos + L, "L", GrapGameObject);
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "L");
            }
            else
            {
                Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "L");
            }
        }

        if (NextAroundBool[3])
        {
            if (AroundRoom(R))
            {
                RangeRoom(NewPos + R, "R", GrapGameObject);
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "R");
            }
            else
            {
                Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "R");
            }
        }

        Destroy(Plane.GetComponent<RoomWallInstan>());
        Destroy(this.gameObject.GetComponent<HoleRoomGenerate>());
    }

    void RangeRoom(Vector3 NewPos, string Entrance, GameObject GrapGameObject)
    {
        int NextRoomType;
        if (ClassRoom.RoomCount > 10 && ClassRoom.RoomCount == 1)
        {
            NextRoomType = Random.Range(0, HoleRoomList.Count);
        }
        else if (ClassRoom.RoomCount >= 30)
        {
            NextRoomType = 0;
        }
        else
        {
            NextRoomType = Random.Range(1, HoleRoomList.Count);
        }

        GameObject NewRoom;
        NewRoom = Instantiate(HoleRoomList[NextRoomType], NewPos, Quaternion.identity, GrapGameObject.transform);
        //NewRoom = Instantiate(HoleRoomList[1], NewPos, Quaternion.identity, GrapGameObject.transform);
        NewRoom.name = "HoleRoom";

        switch (Entrance)
        {
            case "F":
                //NewRoom.transform.localEulerAngles = new Vector3(0, 0, 0);
                NewRoom.transform.localEulerAngles = new Vector3(0, 0, 0);
                break;
            case "B":
                //NewRoom.transform.localEulerAngles = new Vector3(0, 180, 0);
                NewRoom.transform.localEulerAngles = new Vector3(0, 180, 0);
                break;
            case "L":
                //NewRoom.transform.localEulerAngles = new Vector3(0, 270, 0);
                NewRoom.transform.localEulerAngles = new Vector3(0, 270, 0);
                break;
            case "R":
                //NewRoom.transform.localEulerAngles = new Vector3(0, 90, 0);
                NewRoom.transform.localEulerAngles = new Vector3(0, 90, 0);
                break;
        }

        //ExporTo(NewRoom, Entrance);
        //if (!NewRoom.gameObject.GetComponent<HoleRoomGenerate>().enabled)
        //{
        //    NewRoom.gameObject.GetComponent<HoleRoomGenerate>().enabled = true;
        //}

        ClassRoom.RV3 = NewRoom.transform.position;
        GameObject.Find("RoomScenes").GetComponent<RoomList>().RoomData();

        //Destroy(this.gameObject);
    }

    bool AroundRoom(Vector3 NextRoomPos)
    {
        //var NRP = this.transform.position + NextRoomPos;
        foreach (Vector3 NRP in ClassRoom.RList)
        {
            //print(NRP);
            if (NRP == (this.transform.position + NextRoomPos))
            {
                return false;
            }
        }
        return true;
    }

    void ExporTo(/*GameObject NewRoomExit, string Entrance*/)
    {
        var OpenF = AroundBool[0];
        var OpenB = AroundBool[1];
        var OpenL = AroundBool[2];
        var OpenR = AroundBool[3];
        Plane = transform.GetChild(0).gameObject;
        switch (transform.localEulerAngles.y)
        {
            case 0:
                NextAroundBool[0] = OpenF;
                NextAroundBool[1] = OpenB;
                NextAroundBool[2] = OpenL;
                NextAroundBool[3] = OpenR;
                break;
            case 90:
                NextAroundBool[0] = OpenL;
                NextAroundBool[1] = OpenR;
                NextAroundBool[2] = OpenB;
                NextAroundBool[3] = OpenF;
                break;
            case 180:
                NextAroundBool[0] = OpenB;
                NextAroundBool[1] = OpenF;
                NextAroundBool[2] = OpenR;
                NextAroundBool[3] = OpenL;
                break;
            case 270:
                NextAroundBool[0] = OpenR;
                NextAroundBool[1] = OpenL;
                NextAroundBool[2] = OpenF;
                NextAroundBool[3] = OpenB;
                break;
        }

    }
}