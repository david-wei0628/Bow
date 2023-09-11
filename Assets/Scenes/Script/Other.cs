using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    public List<bool> Exit ;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            print("");
        }
    }

    public void RoomExit()
    {
        print(RoomExitValue.Toon);
    }
}

public class RoomExitValue
{
    public static List<bool> Toon;
}