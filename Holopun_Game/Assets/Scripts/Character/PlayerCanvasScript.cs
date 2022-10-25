using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCanvasScript : MonoBehaviour
{
    //Canvas
    public InputActionReference eventButtonCanvas = null;
    [SerializeField] private GameObject m_canvasOptions;
    private bool b_used = false;

    // Start is called before the first frame update
    void Start()
    {
        m_canvasOptions.SetActive(false);
        eventButtonCanvas.action.performed += UseCanvas;
    }
    
    private void UseCanvas(InputAction.CallbackContext context)
    {
        //Add some dotween
        if(b_used == false)
        {
            m_canvasOptions.SetActive(true);
            b_used = true;
        }
        else
        {
            m_canvasOptions.SetActive(false);
            b_used = false;
        }
    }
}
