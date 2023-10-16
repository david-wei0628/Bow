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
    public List<Vector3> RoomPrefabPosData;
    public List<Vector3> RoomPrefabRotData;
    public List<GameObject> RoomBranch;
    public Dictionary<int, LevelBool> NextRoomIns = new Dictionary<int, LevelBool>();
    public List<int> RoomLevel;
    public int LastLevel = 0;
    public bool RoomEven = true;
    public List<int> RoomID;
    public List<int> RoomPrefabID;
    public List<string> RoomName;

    //public List<GameObject> ParentRoomPrefab;
    private void Awake()
    {
        //if (this.gameObject.name == "RoomScenesType1")
        //{
        //RoomPos.Add(Vector3.zero);
        RoomPrefab.Add(StartRoom);
        RoomBranch.Add(StartRoom);
        RoomLevel.Add(0);

        RoomPrefabID.Add(7);
        RoomPrefabPosData.Add(StartRoom.transform.position);
        RoomPrefabRotData.Add(StartRoom.transform.localEulerAngles);
        RoomName.Add(StartRoom.name);
        RoomID.Add(0);

        ClassRoom.RoomCount = RoomPrefab.Count;
        //LevelBool FlashRom = new LevelBool();
        //FlashRom.level = 0;
        //FlashRom.Bool = true;  

        //NextRoomIns.Add(0, FlashRom);

        ClassRoom.RList = RoomPrefab;
        //}
    }

    public void RoomData()
    {
        RoomPrefab.Add(ClassRoom.RV3);
        RoomBranch.Add(ClassRoom.RBG);

        RoomPrefabPosData.Add(ClassRoom.RV3.transform.position);
        RoomPrefabRotData.Add(ClassRoom.RV3.transform.localEulerAngles);
        RoomName.Add(ClassRoom.RV3.name);
        RoomID.Add(ClassRoom.RoomID);
        RoomPrefabID.Add(ClassRoom.RoomPrefabID);
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

    public void DoSerializeAndSave()
    {
        RoomListData Roomdata = new();

        Roomdata.ID = RoomID;
        Roomdata.RoomName = RoomName;
        Roomdata.Level = RoomLevel;
        Roomdata.RoomPosData = RoomPrefabPosData;
        Roomdata.RoomRotData = RoomPrefabRotData;
        Roomdata.RoomData = RoomPrefab;
        Roomdata.RoomPreFabID = RoomPrefabID;

        var json = JsonUtility.ToJson(Roomdata);

        var savePath = Application.persistentDataPath;

        System.IO.File.WriteAllText($"{savePath}/RoomData.json", json);

        Debug.Log($"保存到{ savePath}/ RoomData.json");
    }

    public RoomListData LoadAndDeserialize()
    {
        // 獲取存檔位置
        var savePath = Application.persistentDataPath;

        try//直接讀取有可能讀不到檔案(因為存檔沒有建立) 可以使用例外處理
        {
            //檔案怎麼存就怎麼讀
            var json = System.IO.File.ReadAllText($"{savePath}/RoomData.json");
            //反序列化成PlayerData物件
            var newPlayerData = JsonUtility.FromJson<RoomListData>(json);
            //回傳腳色資料
            return newPlayerData;
        }
        catch
        {
            return null;
        }

    }

    public void ReadRoomList()
    {
        RoomListData roomListData = LoadAndDeserialize();
        if (roomListData == null)
        {
        }
        else
        {
            RoomLevel = roomListData.Level;
            //RoomPrefab = roomListData.RoomData;
            for (int i = 1; i < roomListData.RoomData.Count; i++)
            {
                GameObject RoomObject;
                RoomObject = gameObject.GetComponent<RoomListType2>().RoomObjectInital(roomListData.RoomPreFabID[i]);
                RoomObject.name = "Room " + i;
                RoomObject.transform.position = roomListData.RoomPosData[i];
                RoomObject.transform.localEulerAngles = roomListData.RoomRotData[i];
                RoomPrefab.Add(RoomObject);
                if (LastLevel < RoomLevel[i])
                {
                    LastLevel = RoomLevel[i];
                }
            }
            gameObject.GetComponent<RoomListType2>().MiniMapPlane();
        }

    }
}

public class ClassRoom
{
    public static GameObject RV3;
    public static GameObject RBG;
    public static List<GameObject> RList;
    public static int RoomCount;
    public static int RoomID;
    public static bool[] RoomAround = new bool[4];
    public static bool RoomBool;
    public static int RoomPrefabID;
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

public class RoomListData
{
    public List<int> ID;
    public List<string> RoomName;
    public List<int> Level;
    public List<Vector3> RoomPosData;
    public List<Vector3> RoomRotData;
    public List<GameObject> RoomData;
    public List<int> RoomPreFabID;
}