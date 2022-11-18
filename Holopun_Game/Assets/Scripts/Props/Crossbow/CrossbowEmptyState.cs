using UnityEngine;

public class CrossbowEmptyState : MonoBehaviour
{
    private CrossbowMachineState m_machineState;
    private MonoBehaviour m_chargedState;

    [SerializeField] private float v_sizeTrigger;
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
        Collider[] detectObject = Physics.OverlapSphere(m_posTrigger.position, v_sizeTrigger, m_arrowLayer);

        foreach (Collider arrow in detectObject)//Detect arrow orverlap
        {
            if (arrow.GetComponent<ArrowScript>().shoted == false)
            {
                DetectArrow(arrow.gameObject);
            }
        }
    }

    private void DetectArrow(GameObject arrow)
    {
        //Debug.Log("Detecto flecha");
        arrow.GetComponent<ArrowScript>().DesactiveCollisions();

        arrow.GetComponent<ArrowScript>().arrowCharged = true;
        arrow.GetComponent<ArrowScript>().ChangeArrowChargedCallback += m_machineState.DesatachArrow;

        arrow.transform.SetParent(m_posTrigger);

        arrow.transform.localPosition = new Vector3(0,0,0.025f); //Edit Local position
        arrow.transform.localEulerAngles = new Vector3(0, 0, 90); //Edit Local rotation

        m_machineState.arrow = arrow;
        m_machineState.ChangeState(m_chargedState);//Next state
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(m_posTrigger.position, v_sizeTrigger);
    }
}
