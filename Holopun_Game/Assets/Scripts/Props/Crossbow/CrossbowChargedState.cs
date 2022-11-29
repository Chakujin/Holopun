using UnityEngine;
using UnityEngine.InputSystem;

public class CrossbowChargedState : MonoBehaviour
{
    private CrossbowMachineState m_machineState;
    private MonoBehaviour m_emptyState;

    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private InputActionReference m_buttonShot;
    private GameObject m_arrow;

    // Start is called before the first frame update
    void Awake()
    {
        m_machineState = GetComponent<CrossbowMachineState>();
        m_emptyState = m_machineState.CrossbowEmptyState;
    }

    private void OnEnable()
    {
        if (m_machineState.arrow != null)
        {
            m_arrow = m_machineState.arrow;
        }
    }

    public void ShotArrow()
    {
        if (m_arrow != null)
        {
            //Take currentPlayer
            m_arrow.GetComponent<ArrowScript>().playerShot = m_machineState.playerGrab;

            //Shot Arrow
            m_arrow.transform.parent = null;
            m_arrow.GetComponent<ArrowScript>().ActiveCollisions();

            m_audioSource.Play();

            m_machineState.ChangeState(m_emptyState);
            m_arrow = null;
        }
    }
}
