using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixHeadRotation : MonoBehaviour
{
    [SerializeField] private Transform currenTransform;

    [SerializeField]private float fixRot;

    // Update is called once per frame
    void Update()
    {
        fixRot = currenTransform.localEulerAngles.y;
        
        if(fixRot > 60 && fixRot < 300)
        {
            Debug.Log("Positivo");
        }
        if(fixRot > 300 && fixRot > 60)
        {
            Debug.Log("Negativo");
        }
    }
}
