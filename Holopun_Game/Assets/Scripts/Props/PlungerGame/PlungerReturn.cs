using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerReturn : MonoBehaviour
{
    [SerializeField] private GameObject m_plungerPool;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plunger")
        {
            ReturnPlunger(other.gameObject);
        }
    }

    private void ReturnPlunger(GameObject plunger)
    {
        Debug.Log("PlungerWater");
        plunger.transform.parent = m_plungerPool.transform;

        plunger.transform.position = Vector3.zero;
        plunger.transform.localEulerAngles = Vector3.zero;

        plunger.SetActive(false);
    }
}
