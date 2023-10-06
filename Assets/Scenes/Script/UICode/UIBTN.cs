using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIBTN : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public GameObject UIMenu;
    public GameObject PlayerCS;
    Vector3 UIPlanePos = new Vector3(960, 540, 0);
    public void UIPlaneBTN_event()
    {
        if (GameObject.Find(UIMenu.name))
        {
            Destroy(GameObject.Find(UIMenu.name));
        }
        else
        {
            GameObject UIPlane = Instantiate(UIMenu, UIPlanePos, Quaternion.identity, this.gameObject.transform);
            UIPlane.name = "Panel";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        try
        {
            PlayerCS.GetComponent<PlayMove>().UIBool = false;
        }
        catch
        {
            
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {        
        try
        {
            PlayerCS.GetComponent<PlayMove>().UIBool = true;
        }
        catch
        {
          
        }
    }

    public void InitialRoomBTN_even()
    {
        GameObject.Find("AL").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("AL").transform.GetChild(1).gameObject.SetActive(false);
        Destroy(GameObject.Find(UIMenu.name));
    }

    public void ReadBTN_even()
    {
        GameObject.Find("AL").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("AL").transform.GetChild(1).gameObject.SetActive(true);
        Destroy(GameObject.Find(UIMenu.name));
    }

    public void InitialSceneBTN_even()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
