using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCylinder : MonoBehaviour
{
    [SerializeField] private Renderer m_renderer;
    private bool b_hited = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plunger" && b_hited == false)
        {
            GameObject myObject = other.gameObject;

            if(myObject.GetComponent<PlungerScript>().CompareDirection() == true)
            {
                PlungerInside(myObject);
            }
            else
            {
                Debug.Log("Trigeado pero no colocado");
            }
        }
    }

    private void PlungerInside(GameObject plunger)
    {
        //Reset positions to add fixed
        plunger.transform.parent = transform;
        plunger.transform.localPosition = Vector3.zero;
        plunger.transform.localEulerAngles = transform.localEulerAngles;

        //Ennable false movement
        Rigidbody rb = plunger.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        b_hited = true;

        //Change Alpha color to 100% alpha
        Color color = m_renderer.material.color;
        color.a = 0;
        m_renderer.material.color = color;

        //Evento añadir puntos
    }
}
