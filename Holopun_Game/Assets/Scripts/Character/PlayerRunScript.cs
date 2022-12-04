using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunScript : MonoBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider m_continusMove;
    private float f_currentSped;
    private float f_maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        f_currentSped = m_continusMove.moveSpeed;
    }

    public void RunPlayer (InputAction.CallbackContext context)
    {
        m_continusMove.moveSpeed = f_maxSpeed;
    }
}
