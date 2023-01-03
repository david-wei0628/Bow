using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    public float ArrowSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector3(0, 0.213f, -0.23f);
        this.GetComponent<Collider>().enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().velocity = this.transform.forward * ArrowSpeed;
            this.GetComponent<Rigidbody>().useGravity = true;
            Invoke("ShootIng",0.1f);
        }

    }

    void ShootIng()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<ArrowHit>().enabled = true;
        this.GetComponent<ArrowShot>().enabled = false;
        this.transform.parent = null;
    }
}
