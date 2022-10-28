using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowEmptyState : MonoBehaviour
{
    private CrossbowMachineState m_machineState;
    private MonoBehaviour m_chargedState;

    [SerializeField] private Vector3 v_sizeTrigger;
    [SerializeField] private Transform m_posTrigger;
    [SerializeField] private LayerMask m_arrowLayer;

    // Start is called before the first frame update
    void Start()
    {
        m_machineState = GetComponent<CrossbowMachineState>();
        m_chargedState = m_machineState.CrossbowChargedState;
    }

    private void FixedUpdate()
    {
        Collider[] detectObject = Physics.OverlapBox(m_posTrigger.position, v_sizeTrigger, m_posTrigger.localRotation, m_arrowLayer);

        foreach (Collider arrow in detectObject)//Detect arrow orverlap
        {
            DetectArrow(arrow.gameObject);
        }
    }

    private void DetectArrow(GameObject arrow)
    {
        arrow.GetComponent<BoxCollider>().enabled = false;
        arrow.transform.SetParent(m_posTrigger);

        m_machineState.arrow = arrow;
        m_machineState.ChangeState(m_chargedState);//Next state
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(m_posTrigger.position, v_sizeTrigger);
    }
}
