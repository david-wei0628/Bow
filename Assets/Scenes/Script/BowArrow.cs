using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowArrow : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject ArrowBone;
    public Animator Us;
    public float ArrowSpeed = 10f;
    float max=-2.76f;
    bool ArrowHold = false;
    // Start is called before the first frame update
    void Start()
    {
        Us = GetComponent<Animator>();
        Arrow_SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ArrowBone.transform.localPosition.y <= max)
        {
            //Arrow_SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Us.SetBool("OnArrow",true);
            ArrowHold = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && ArrowBone.activeSelf)
        {
            Us.SetBool("Fir", true);
            Us.SetBool("OnArrow", false);
            ArrowHold = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && ArrowHold)
        {
            //Arrow.SetActive(true);
            Arrow_SetActive(true);
            Instantiate(Arrow, this.transform);
            //Instantiate(Arrow);
        }
    }

    void Arrow_SetActive(bool ArSelf)
    {
        Arrow.SetActive(ArSelf);
        ArrowBone.SetActive(ArSelf);
        //ArrowBone.GetComponent<Collider>().enabled = ArSelf;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Arrow_SetActive(false);
    }
}
