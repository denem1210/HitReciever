using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HitReciever : MonoBehaviour
{

    public GameObject m_HiddenObject;
    public GameObject m_BaseObject;
    public GameObject m_ThisRoom;
    public Transform m_NextRoom;





    // Start is called before the first frame update
    void Start()
    {
        
        

    }


    public void SelectionConfirmed()
    {
        BoxCollider thisCollider = m_BaseObject.GetComponent<BoxCollider>();

        thisCollider.enabled = false;

        if (m_HiddenObject != null)
        {
            m_HiddenObject.SetActive(true);
        }

        
        Debug.Log("Selection confirmed");

        

        
        
    }

    private void getDestination ()
    {
        if (m_NextRoom != null)
        {
            Vector3 destinationV3 = m_NextRoom.GetComponent<Vector3>();

            m_ThisRoom.transform.position = destinationV3;

            
        }

    }


    // Update is called once per frame
    void Update()
    {
        /*if(m_thisRoom != null)
        {
            m_Level = null;
            m_SelectionOptions = null;
            Debug.Log("This method cannot load a level and activate selection options");
        }
        if (m_SelectionOptions != null)
        {
            m_thisRoom = null;
            m_Level = null;
            Debug.Log("This method cannot activate a camera and activate selection options");
        }*/
    }

}
