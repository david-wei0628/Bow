using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleRoomListController : MonoBehaviour
{
    public List<GameObject> RoomList;

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void RoomData()
    {
        RoomList = gameObject.GetComponent<HoleRoomList>().RoomPrefab;
    }

}


