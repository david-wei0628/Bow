using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// passive script 
/// Only Log Room Date(Room's Number,Level Tabel,Branch Room,Room's GameObject)
/// </summary>
public class HoleRoomList : MonoBehaviour
{
    //public List<Vector3> RoomPos;
    public GameObject StartRoom;
    public List<AroundBool> StartAround = new List<AroundBool>();
    public List<GameObject> RoomPrefab;
    public List<GameObject> RoomBranch;
    public Dictionary<int, LevelBool> NextRoomIns = new Dictionary<int, LevelBool>();
    public List<int> RoomLevel;
    public int LastLevel = 0;
    public bool RoomEven = true;

    //public List<GameObject> ParentRoomPrefab;
    private void Awake()
    {
        //RoomPos.Add(Vector3.zero);
        RoomPrefab.Add(StartRoom);
        RoomBranch.Add(StartRoom);
        RoomLevel.Add(0);

        //LevelBool FlashRom = new LevelBool();
        //FlashRom.level = 0;
        //FlashRom.Bool = true;  

        //NextRoomIns.Add(0, FlashRom);

        ClassRoom.RList = RoomPrefab;
    }

    public void RoomData()
    {
        RoomPrefab.Add(ClassRoom.RV3);
        RoomBranch.Add(ClassRoom.RBG);
        //NextRoomIns.Add();
        RoomLevel.Add(0);
        Level();
        ClassRoom.RList = RoomPrefab;
        ClassRoom.RoomCount = RoomPrefab.Count;
    }

    public void RA(GameObject RV3)
    {
        AroundBool Around = new AroundBool();
        Around.list = ClassRoom.RoomAround;
        StartAround.Add(Around);

        var i = RoomPrefab.FindIndex(x => x == RV3);
        var index = RoomPrefab.FindIndex(x => x == RoomBranch[i]);

        LevelBool FlashRom = new LevelBool();
        FlashRom.level = RoomLevel[i];
        FlashRom.Bool = ClassRoom.RoomBool;
        NextRoomIns.Add(i, FlashRom);
    }

    public void Level()
    {
        var i = RoomPrefab.FindIndex(x => x == ClassRoom.RV3);
        var index = RoomPrefab.FindIndex(x => x == RoomBranch[i]);
        RoomLevel[i] = RoomLevel[index] + 1;

        if (LastLevel < RoomLevel[RoomLevel.Count - 1])
        {
            LastLevel = RoomLevel[RoomLevel.Count - 1];
        }
    }    
}

public class ClassRoom
{
    public static GameObject RV3;
    public static GameObject RBG;
    public static List<GameObject> RList;
    public static int RoomCount;
    public static bool[] RoomAround = new bool[4];
    public static bool RoomBool;
}

[System.Serializable]
public class AroundBool
{
    //public List<bool> list = new List<bool>(ClassRoom.RoomAround.Length);
    public bool[] list = new bool[4];
}

[System.Serializable]
public class LevelBool
{
    //public List<bool> list = new List<bool>(ClassRoom.RoomAround.Length);
    public int level;
    public bool Bool;
}
