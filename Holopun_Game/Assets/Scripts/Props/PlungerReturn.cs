using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerReturn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plunger")
        {
            Debug.Log("Plunger drops on water");
        }
    }
}
