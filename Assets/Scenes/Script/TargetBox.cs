using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBox : MonoBehaviour
{
    public GameObject Target;
    float time_f = 0f;
    Vector3 Random_Vector3;
    int BoxQuantity;
    // Start is called before the first frame update
    void Start()
    {
        BoxQuantity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (BoxQuantity < 10)
        {
            time_f += Time.deltaTime*2;
            if (Mathf.FloorToInt(time_f) > 1)
            {
                Random_Vector3= new Vector3(Random.Range(300f, 400f), 20f, Random.Range(300f, 400f));
                BoxInst(Random_Vector3);
                time_f = 0f;
            }
        }
    }

    void BoxInst(Vector3 Box_pos)
    {
        BoxQuantity++;
        Instantiate(Target, Box_pos, Quaternion.identity, this.transform);
    }

    void BoxClear()
    {
        BoxQuantity--;
    }

}
