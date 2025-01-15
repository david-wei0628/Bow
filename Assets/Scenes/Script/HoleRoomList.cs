using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using Newtonsoft.Json;

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
    public List<string> RoomBranchName;
    public Dictionary<int, LevelBool> NextRoomIns = new Dictionary<int, LevelBool>();
    public List<LevelBool> NextRoomInsa;
    public List<int> RoomLevel;
    public int LastLevel = 0;
    public bool RoomEven = true;
    public List<int> RoomID;
    public List<int> RoomPrefabID;
    public List<string> RoomName;

    //RoomListData Roomdata = new();
    //public List<GameObject> ParentRoomPrefab;
    private void Awake()
    {
        //if (this.gameObject.name == "RoomScenesType1")
        //{
        //RoomPos.Add(Vector3.zero);
        RoomPrefab.Add(StartRoom);
        RoomBranch.Add(StartRoom);
        RoomBranchName.Add(StartRoom.name);
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
        RoomBranchName.Add(ClassRoom.RBG.name);

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
        //var index = RoomPrefab.FindIndex(x => x == RoomBranch[i]);
        LevelBool FlashRom = new LevelBool();
        FlashRom.level = RoomLevel[i];
        FlashRom.Bool = ClassRoom.RoomBool;
        NextRoomIns.Add(i,FlashRom);
        NextRoomInsa.Add(FlashRom);
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
        Roomdata.RoomPreFabID = RoomPrefabID;
        Roomdata.RoomBranchName = RoomBranchName;

        var json = JsonUtility.ToJson(Roomdata);

        var savePath = Application.persistentDataPath;

        System.IO.File.WriteAllText($"{savePath}/RoomData.json", json);

        Debug.Log($"�O�s��{ savePath}/ RoomData.json");
    }

    public RoomListData LoadAndDeserialize()
    {
        // ����s�ɦ�m
        var savePath = Application.persistentDataPath;

        try//����Ū�����i��Ū�����ɮ�(�]���s�ɨS���إ�) �i�H�ϥΨҥ~�B�z
        {
            //�ɮ׫��s�N���Ū
            var json = System.IO.File.ReadAllText($"{savePath}/db.json");
            //�ϧǦC�Ʀ�PlayerData����
            var newPlayerData = JsonUtility.FromJson<RoomListData>(json);
            //StartCoroutine(webjson());
            
            //�^�Ǹ}����
            return newPlayerData;
        }
        catch
        {
            return null;
        }

    }

    public void ReadStart() => StartCoroutine(webjson());

    IEnumerator webjson()
    {
        var SavePath = "https://raw.githubusercontent.com/david-wei0628/Dungeon/main/RoomData.json";
        var json2 = UnityWebRequest.Get(SavePath);
        yield return json2.SendWebRequest();
                print(json2.downloadedBytes);
        var ReadToJsonText = json2.downloadHandler.text;
        ReadRoomList(ReadToJsonText);
    }

    public void ReadRoomList(string RoomDataJson)
    {
        //RoomListData roomListData = LoadAndDeserialize();
        var roomListData = JsonUtility.FromJson<RoomListData>(RoomDataJson);

        if (roomListData == null)
        {
        }
        else
        {
            RoomLevel = roomListData.Level;
            for (int i = 1; i < roomListData.ID.Count; i++)
            {
                GameObject RoomObject;
                RoomObject = gameObject.GetComponent<RoomListType2>().RoomObjectInital(roomListData.RoomPreFabID[i]);
                RoomObject.name = roomListData.RoomName[i];
                RoomObject.transform.position = roomListData.RoomPosData[i];
                RoomObject.transform.localEulerAngles = roomListData.RoomRotData[i];

                RoomPrefab.Add(RoomObject);
                GameObject BranchObject = RoomPrefab.Find(R => R.name == roomListData.RoomBranchName[i]);
                RoomBranch.Add(BranchObject);

                LastLevel = Mathf.Max(LastLevel,RoomLevel[i]);
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
    public List<string> RoomBranchName;
    public List<int> Level;
    public List<Vector3> RoomPosData;
    public List<Vector3> RoomRotData;
    public List<int> RoomPreFabID;
}