using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerScript : MonoBehaviour
{
    //[SerializeField] Transform m_raycastPosition;
    [SerializeField] float f_rangeRaycast;
    public bool CompareDirection()
    {
        //Start raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward , out hit, f_rangeRaycast))
        {
            if (hit.collider.tag == "ObjectDest")
            {
                return true;
            }
            Debug.Log(hit.transform.gameObject);
            Debug.DrawRay(transform.position, transform.forward , Color.green);
        }
        return false;
    }
}
