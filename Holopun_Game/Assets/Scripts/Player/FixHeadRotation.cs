using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixHeadRotation : MonoBehaviour
{
    [SerializeField] private Transform target;
    //[SerializeField] private Transform COG;

    [SerializeField] private float fixRot;
    [SerializeField] private float COGfix;
    public Vector3 startPos;


    // Update is called once per frame
    void Update()
    {
        transform.rotation = target.rotation;

        /*
        if(fixRot > 60 && fixRot < 300)
        {
            Debug.Log("Positivo");
            COG.localEulerAngles = new Vector3(0,0,fixRot);
        }
        if(fixRot > 300 && fixRot > 60)
        {
            Debug.Log("Negativo");
            COG.localEulerAngles = new Vector3(0, 0, fixRot);
        }
        */
    }
}
