using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class PlayerRunScript : MonoBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider m_continusMove;
    private int i_currentSped;
    private int i_maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
