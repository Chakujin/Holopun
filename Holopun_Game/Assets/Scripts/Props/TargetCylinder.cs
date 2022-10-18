using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCylinder : MonoBehaviour
{
    private bool b_hited = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plunger" && b_hited == false)
        {
            GameObject myObject = other.gameObject;

            if(myObject.GetComponent<PlungerScript>().CompareDirection() == true)
            {
                //Reset positions to add fixed
                myObject.transform.parent = transform;
                myObject.transform.localPosition = Vector3.zero;
                myObject.transform.localEulerAngles = transform.localEulerAngles;

                //Ennable false movement
                Rigidbody rb = myObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                b_hited = true;
                //Evento añadir puntos
            }
            else
            {
                Debug.Log("Trigeado pero no colocado");
            }
        }
    }
}
