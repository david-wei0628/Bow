using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBtnActive : MonoBehaviour
{
    public Button InitalBtn;
    public Button ReadBtn;
    public Button SaveBtn;

    void Awake()
    {
        var savePath = Application.persistentDataPath;

        try
        {
            var json = System.IO.File.ReadAllText($"{savePath}/RoomData.json");
            ReadBtn.enabled = true;
        }
        catch
        {
            ReadBtn.enabled = false;
        }
    }

}
