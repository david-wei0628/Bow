using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIBTN : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public GameObject UIMenu;
    public GameObject PlayerCS;
    public GameObject Type1;
    public GameObject Type2;
    public GameObject MiniMap;

    public GameObject DoorORWall;
    //public RoomListData RoomData;

    Vector3 UIPlanePos = new Vector3(960, 540, 0);
    public void UIPlaneBTN_event()
    {
        if (GameObject.Find(UIMenu.name))
        {
            Destroy(GameObject.Find(UIMenu.name));
        }
        else
        {
            GameObject UIPlane = Instantiate(UIMenu, UIPlanePos, Quaternion.identity, this.gameObject.transform);
            UIPlane.name = "Panel";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        try
        {
            PlayerCS.GetComponent<PlayMove>().UIBool = false;
        }
        catch
        {

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        try
        {
            PlayerCS.GetComponent<PlayMove>().UIBool = true;
        }
        catch
        {

        }
    }

    public void InitialRoomBTN_even()
    {
        //GameObject.Find("AL").transform.GetChild(0).gameObject.SetActive(true);
        //GameObject.Find("AL").transform.GetChild(1).gameObject.SetActive(false);

        DoorWallGrap();

        if (!GameObject.Find(Type1.name))
        {
            GameObject RoomList = Instantiate(Type1, Vector3.zero, Quaternion.identity);
            RoomList.name = "RoomScenesType1";
        }
        else
        {
            Destroy(GameObject.Find(Type1.name).gameObject);
            GameObject RoomList = Instantiate(Type1, Vector3.zero, Quaternion.identity);
            RoomList.name = "RoomScenesType1";
        }


        if (GameObject.Find(Type2.name))
        {
            Destroy(GameObject.Find(Type2.name).gameObject);
        }

        Destroy(GameObject.Find(UIMenu.name));
    }

    void DoorWallGrap()
    {
        if (GameObject.Find("DoorORWall"))
        {
            Destroy(GameObject.Find("DoorORWall"));
        }

        GameObject DoorWall = Instantiate(DoorORWall, Vector3.zero, Quaternion.identity);
        DoorWall.name = "DoorORWall";
    }
    
    public void ReadBTN_even()
    {
        DoorWallGrap();

        if (!GameObject.Find(Type2.name))
        {
            GameObject RoomList = Instantiate(Type2, Vector3.zero, Quaternion.identity);
            RoomList.name = "RoomScenesType2";
            RoomList.GetComponent<HoleRoomList>().ReadRoomList();
        }
        else
        {
            Destroy(GameObject.Find(Type2.name).gameObject);
            GameObject RoomList = Instantiate(Type2, Vector3.zero, Quaternion.identity);
            RoomList.name = "RoomScenesType2";
            RoomList.GetComponent<HoleRoomList>().ReadRoomList();
        }


        if (GameObject.Find(Type1.name))
        {
            Destroy(GameObject.Find(Type1.name).gameObject);
        }

        Destroy(GameObject.Find(UIMenu.name));
    }

    public void InitialSceneBTN_even()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveRoomListBtn_even()
    {
        try
        {
            GameObject RoomGrap = GameObject.Find("RoomScenesType1");
            //print(RoomGrap.transform.childCount);
            RoomGrap.GetComponent<HoleRoomList>().DoSerializeAndSave();
        }
        catch
        {

        }
    }

}

//public class RoomListData
//{
//    public List<int> ID;
//    public List<string> RoomName;
//    public List<GameObject> RoomData;
//    public List<int> Level;
//    public List<GameObject> BranchRoom;
//    public List<int> ModeID;
//}