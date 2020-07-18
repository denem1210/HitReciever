using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class selector2 : MonoBehaviour
{
    private Camera m_mainCamera;
    public float m_rayDistance;
    private GameObject m_SelectionManager = null;
    public float m_SelectionTime;
    public bool m_IsHitting = false;
    public bool PT_Running = false;
    public string m_Tag;
    public Image m_UICanvas;
    public Animator m_Animator;
    public float m_WaitTime;
    




    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = GetComponentInParent<Camera>();
        //m_UICanvas.fillAmount += 1.0f / m_WaitTime * Time.deltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        int layerMask = 7 << 8;
        



        // This also works
        // Not as quick to react as selector3 however
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, m_rayDistance, layerMask))
        {
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            var itemThatWasHit = hit.collider.gameObject;
            m_SelectionManager = itemThatWasHit;

            m_IsHitting = true;
            //selectionManager.m_Selection = itemThatWasHit;
            m_UICanvas.fillAmount += 1.0f / m_WaitTime * Time.deltaTime;
            //check to see if the projected timer coroutine is not running
            if (PT_Running == false)
            {
                
                StartCoroutine("ProjectedTimer");
                /*if (m_UICanvas.fillAmount <= 0.1f)
                {
                    m_UICanvas.fillAmount += 0.1f / m_WaitTime * Time.deltaTime;
                }*/
            }
            

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * m_rayDistance, Color.red);
            m_SelectionManager = null;
            //selectionManager.m_IsHitting = false;
            //selectionManager.m_Selection = null;
            m_IsHitting = false;
            /*if (PT_Running == true)
            {
                if (m_UICanvas.fillAmount <= 1.0f)
                {
                    m_UICanvas.fillAmount -= 0.1f / m_WaitTime * Time.deltaTime;
                }
            }*/
            m_UICanvas.fillAmount -= 1.0f / m_WaitTime * Time.deltaTime;
            PT_Running = false;
        }

        

        

    }


    //coroutine for the selection timer, it is called projected timer as there were originaly going to be two timers, a current and projected timer.
    private void ProjectedTimer()
    {
        //set a bool that will be used to determine whether or not the coroutine is running
        if (m_UICanvas.fillAmount == 1.0f) // this does not seem to work but its also not negatively affecting the script either
        {
            PT_Running = true;

            //float timerLegnth = m_WaitTime;

            Debug.Log("Timer started");

            //yield return new WaitForSeconds(timerLegnth);

            Debug.Log("Timer Complete");

            if (m_IsHitting == true)
            {
                Debug.Log("Initiate selection");
                m_SelectionManager.GetComponent<HitReciever>().SelectionConfirmed();
                PT_Running = false;

            }
            else
            {
                Debug.Log("Selection Cancelled");

                PT_Running = false;
            }
        }
        

        

    }

}
