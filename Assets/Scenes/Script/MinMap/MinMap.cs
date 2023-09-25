using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMap : MonoBehaviour
{
    public Transform LookObject;
    public Transform LightPos;
    private void LateUpdate()
    {
        LightPos.position = new Vector3(LookObject.position.x, LightPos.position.y, LookObject.position.z);
        LightPos.localEulerAngles = new Vector3(0, LookObject.localEulerAngles.y, 0);
    }
}
