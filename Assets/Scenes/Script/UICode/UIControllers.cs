using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllers : MonoBehaviour
{
    public GameObject mesh;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            // PlayerPrefs.Save();
            //DataJson();
        }
    }

    //void DataJson()
    //{
    //    var json = JsonUtility.ToJson(mesh.tag);
    //    Debug.Log(json.ToString());
    //}
}
