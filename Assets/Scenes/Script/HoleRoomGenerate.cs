using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Next Room Instantiate And Its Wall Instantiate
/// Wall Instantiate Opportunity  is earlier than Next Room Instantiate Opportunity
/// </summary>
public class HoleRoomGenerate : MonoBehaviour
{
    public List<GameObject> HoleRoomPrefabList;
    [SerializeField]
    private bool[] AroundBool = new bool[4];
    //0->Forward|1->Back|2->Left|3->Right
    bool[] NextAroundBool = new bool[4];
    bool LastRound = false;

    private GameObject Plane;
    private bool DWINS = true;
    string ParentGroup;
    //Vector3 F = new Vector3(0, 10, 10);
    Vector3 F = Vector3.forward * 10;
    //Vector3 B = new Vector3(0, 10, -10);
    Vector3 B = Vector3.back * 10;
    //Vector3 L = new Vector3(-10, 10, 0);
    Vector3 L = Vector3.left * 10;
    //Vector3 R = new Vector3(10, 10, 0);
    Vector3 R = Vector3.right * 10;

    void Start() => ExporTo(); 

    private void FixedUpdate()
    {
        if (Plane.transform.position.y == 0 && DWINS)
        {
            switch (ParentGroup)
            {
                case "RoomScenesType1":
                    DoorWallType1();
                    break;
                case "RoomScenesType2":
                    DoorWallType2();
                    break;

            }
        }
    }

    /// <summary>
    /// ¶¡¶Z10
    /// </summary>
    public void HoleRoomBuilder(bool LastFlag)
    {
        Vector3 NewPos = this.transform.position;
        GameObject GrapGameObject = gameObject.transform.parent.gameObject;
        //ClassRoom.RV3 = this.gameObject;
        //GameObject.Find("RoomScenes").GetComponent<RoomList>().RoomData();
        LastRound = LastFlag;
        NextRoomIns(NewPos, GrapGameObject);

        //Destroy(Plane.GetComponent<RoomWallInstan>());
        Destroy(this.gameObject.GetComponent<HoleRoomGenerate>());
    }

    void RangeRoom(Vector3 NewPos, string Entrance, GameObject GrapGameObject)
    {
        int NextRoomType;
        if (ClassRoom.RoomCount >= 25 || LastRound)
        {
            NextRoomType = 0;
        }
        else if (ClassRoom.RoomCount < 10)
        {
            NextRoomType = Random.Range(1, HoleRoomPrefabList.Count);
        }
        else
        {
            NextRoomType = Random.Range(0, HoleRoomPrefabList.Count);
        }

        GameObject NewRoom;
        NewRoom = Instantiate(HoleRoomPrefabList[NextRoomType], NewPos, Quaternion.identity, GrapGameObject.transform);

        NewRoom.name = "Room " + ClassRoom.RoomCount.ToString();

        switch (Entrance)
        {
            case "F":
                NewRoom.transform.localEulerAngles = new Vector3(0, 0, 0);
                NewRoom.transform.localEulerAngles = new Vector3(0, 0, 0);
                break;
            case "B":
                NewRoom.transform.localEulerAngles = new Vector3(0, 180, 0);
                NewRoom.transform.localEulerAngles = new Vector3(0, 180, 0);
                break;
            case "L":
                NewRoom.transform.localEulerAngles = new Vector3(0, 270, 0);
                NewRoom.transform.localEulerAngles = new Vector3(0, 270, 0);
                break;
            case "R":
                NewRoom.transform.localEulerAngles = new Vector3(0, 90, 0);
                NewRoom.transform.localEulerAngles = new Vector3(0, 90, 0);
                break;
        }

        ClassRoom.RV3 = NewRoom;
        ClassRoom.RBG = this.gameObject;
        ClassRoom.RoomID = ClassRoom.RoomCount;
        ClassRoom.RoomBool = NextLevelBool();
        ClassRoom.RoomPrefabID = NextRoomType;

        this.gameObject.transform.parent.gameObject.GetComponent<HoleRoomList>().RoomData();

    }

    bool AroundRoom(Vector3 NextRoomPos)
    {
        //var NRP = this.transform.position + NextRoomPos;
        //var NUP1 = ClassRoom.RList.Exists(R => R.transform.position != (this.transform.position + NextRoomPos));
        //print(this.gameObject.name+"/ "+this.transform.position.ToString() + "/" + NextRoomPos.ToString() + "/ " + NUP1);

        foreach (GameObject NRP in ClassRoom.RList)
        {
            if (NRP.transform.position == (this.transform.position + NextRoomPos))
            {
                return false;
            }
        }
        return true;

        //return NUP;

    }

    void ExporTo()
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
        ClassRoom.RoomAround = NextAroundBool;
        //ClassRoom.RoomBool = NextLevelBool();
        ParentGroup = this.gameObject.transform.parent.gameObject.name;
        this.gameObject.transform.parent.gameObject.GetComponent<HoleRoomList>().RA(gameObject);
    }

    void NextRoomIns(Vector3 NewPos, GameObject GrapGameObject)
    {
        if (NextAroundBool[0])
        {
            if (AroundRoom(F))
            {
                RangeRoom(NewPos + F, "F", GrapGameObject);
            }
        }

        if (NextAroundBool[1])
        {
            if (AroundRoom(B))
            {
                RangeRoom(NewPos + B, "B", GrapGameObject);
            }
        }

        if (NextAroundBool[2])
        {
            if (AroundRoom(L))
            {
                RangeRoom(NewPos + L, "L", GrapGameObject);
            }
        }

        if (NextAroundBool[3])
        {
            if (AroundRoom(R))
            {
                RangeRoom(NewPos + R, "R", GrapGameObject);
            }
        }
    }

    public void DoorWallType1()
    {
        if (NextAroundBool[0])
        {
            if (AroundRoom(F))
            {
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "F");
            }
            else
            {
                if (this.transform.localEulerAngles.y == 180)
                {
                    Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "F");
                }
                else
                {
                    Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "F");
                }
            }
        }

        if (NextAroundBool[1])
        {
            if (AroundRoom(B))
            {
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "B");
            }
            else
            {
                if (this.transform.localEulerAngles.y == 0)
                {
                    Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "B");
                }
                else
                {
                    Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "B");
                }
            }
        }

        if (NextAroundBool[2])
        {
            if (AroundRoom(L))
            {
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "L");
            }
            else
            {
                if (this.transform.localEulerAngles.y == 90)
                {
                    Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "L");
                }
                else
                {
                    Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "L");
                }
            }
        }

        if (NextAroundBool[3])
        {
            if (AroundRoom(R))
            {
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "R");
            }
            else
            {
                if (this.transform.localEulerAngles.y == 270)
                {
                    Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "R");
                }
                else
                {
                    Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "R");
                }
            }
        }
        DWINS = false;
        if (this.gameObject.tag == "One")
        {
            Destroy(this.gameObject.GetComponent<HoleRoomGenerate>());
        }
    }

    public void DoorWallType2()
    {
        var BranchList = this.gameObject.transform.parent.gameObject.GetComponent<HoleRoomList>().RoomBranch;
        var RooomList = this.gameObject.transform.parent.gameObject.GetComponent<HoleRoomList>().RoomPrefab;
        if (NextAroundBool[0])
        {
            if (this.transform.localEulerAngles.y == 180 || this.name == "StarHoleRoom")
            {
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "F");
            }
            else
            {
                foreach (GameObject NRP in ClassRoom.RList)
                {
                    if (NRP.transform.position == (this.transform.position + F))
                    {
                        var i = RooomList.FindIndex(x => x == NRP);
                        if (BranchList[i].name == this.name)
                        {
                            Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "F");
                        }
                        else
                        {
                            Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "F");
                        }
                        break;
                    }
                }
            }
        }

        if (NextAroundBool[1])
        {
            if (this.transform.localEulerAngles.y == 0)
            {
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "B");
            }
            else
            {
                foreach (GameObject NRP in ClassRoom.RList)
                {
                    if (NRP.transform.position == (this.transform.position + B))
                    {
                        var i = RooomList.FindIndex(x => x == NRP);
                        if (BranchList[i].name == this.name)
                        {
                            Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "B");
                        }
                        else
                        {
                            Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "B");
                        }
                        break;
                    }
                }
            }
        }

        if (NextAroundBool[2])
        {
            if (this.transform.localEulerAngles.y == 90)
            {
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "L");
            }
            else
            {
                foreach (GameObject NRP in ClassRoom.RList)
                {
                    if (NRP.transform.position == (this.transform.position + L))
                    {
                        var i = RooomList.FindIndex(x => x == NRP);
                        if (BranchList[i].name == this.name)
                        {
                            Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "L");
                        }
                        else
                        {
                            Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "L");
                        }
                        break;
                    }
                }
            }
        }

        if (NextAroundBool[3])
        {
            if (this.transform.localEulerAngles.y == 270)
            {
                Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "R");
            }
            else
            {
                foreach (GameObject NRP in ClassRoom.RList)
                {
                    if (NRP.transform.position == (this.transform.position + R))
                    {
                        var i = RooomList.FindIndex(x => x == NRP);
                        if (BranchList[i].name == this.name)
                        {
                            Plane.GetComponent<RoomWallInstan>().DoorInstanEven(this.transform, "R");
                        }
                        else
                        {
                            Plane.GetComponent<RoomWallInstan>().WallInstanEven(this.transform, "R");
                        }
                        break;
                    }
                }
            }
        }

        DWINS = false;
        Destroy(this.gameObject.GetComponent<HoleRoomGenerate>());
    }

    public bool NextLevelBool()
    {
        bool R4 = false;
        bool Fornt = NextAroundBool[0] & AroundRoom(F);
        bool Back = NextAroundBool[1] & AroundRoom(B);
        bool Left = NextAroundBool[2] & AroundRoom(L);
        bool Right = NextAroundBool[3] & AroundRoom(R);

        R4 = Fornt | Back | Left | Right;

        return R4;
    }

}