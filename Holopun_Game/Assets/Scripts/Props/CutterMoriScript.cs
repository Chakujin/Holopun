using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterMoriScript : MonoBehaviour
{
    private Transform m_positionBox;
    private Vector3 v_size;
    private LayerMask m_interactableLayer;

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] detectObject = Physics.OverlapBox(m_positionBox.position, v_size, Quaternion.identity, m_interactableLayer);

        foreach (Collider obj in detectObject)
        {
            IHiteable _interactable = obj.GetComponent<IHiteable>(); //Get the interface
            if (_interactable != null) //if the interface is not empty
            {
                HitObject(_interactable);
            }
        }
    }
    private void HitObject(IHiteable obj)
    {
        obj.Hited(gameObject);//pass player
    }
}
