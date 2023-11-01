using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UIBtnActive : MonoBehaviour
{
    public Button InitalBtn;
    public Button ReadBtn;
    public Button SaveBtn;

    //void Awake()
    //{
    //    var savePath = Application.persistentDataPath;

    //    try
    //    {
    //        var json = System.IO.File.ReadAllText($"{savePath}/RoomData.json");
    //        ReadBtn.enabled = true;
    //    }
    //    catch
    //    {
    //        ReadBtn.enabled = false;
    //    }
    //}

    private IEnumerator Start()
    {
        var SavePath = "https://raw.githubusercontent.com/david-wei0628/Dungeon/main/RoomData.json";
        var json = UnityWebRequest.Head(SavePath);
        yield return json.SendWebRequest();

        if (json.responseCode == 200)
        {
            ReadBtn.enabled = true;
        }
        else
        {
            ReadBtn.enabled = false;
        }
    }
}
