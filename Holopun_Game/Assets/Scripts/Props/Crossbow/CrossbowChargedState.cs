using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrossbowChargedState : MonoBehaviour
{
    private CrossbowMachineState m_machineState;
    private MonoBehaviour m_emptyState;

    [SerializeField] private InputActionReference m_buttonShot;
    private GameObject m_arrow;

    // Start is called before the first frame update
    void Start()
    {
        m_machineState = GetComponent<CrossbowMachineState>();
        m_emptyState = m_machineState.CrossbowEmptyState;

        m_buttonShot.action.performed += ShotArrow; //Add event to a void
    }

    private void OnEnable()
    {
        m_arrow = m_machineState.arrow;
    }

    private void ShotArrow(InputAction.CallbackContext context)
    {
        m_arrow.transform.parent = null;
        m_arrow.GetComponent<BoxCollider>().enabled = true;
        m_arrow.GetComponent<Rigidbody>().AddForce(m_arrow.transform.forward * 20,ForceMode.Impulse);

        m_machineState.ChangeState(m_emptyState);
    }
}
