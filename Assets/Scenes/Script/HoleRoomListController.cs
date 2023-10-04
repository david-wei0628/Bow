using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleRoomListController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            ObjectTest();
        }
    }

    void ObjectTest()
    {
        var roomList = this.gameObject.GetComponent<HoleRoomList>().RoomPrefab;
        for (int i = 0; i < roomList.Count; i++)
        {
            print(roomList[i].GetInstanceID() + " " + roomList[i].tag);

        }
    }

}


