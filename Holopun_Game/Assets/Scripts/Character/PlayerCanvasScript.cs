using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCanvasScript : MonoBehaviour
{
    //Controllers
    [SerializeField] private GameObject m_leftBaseController;
    [SerializeField] private GameObject m_leftUiController;

    [SerializeField] private GameObject m_rightBaseController;
    [SerializeField] private GameObject m_rightUIController;

    //Canvas
    public InputActionReference eventButtonCanvas = null;
    [SerializeField] private GameObject m_canvasOptions;
    private bool b_used = false;

    [SerializeField] private AudioSource m_audioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_canvasOptions.SetActive(false);
        eventButtonCanvas.action.performed += UseCanvas;
    }
    
    private void UseCanvas(InputAction.CallbackContext context)
    {
        //Add some dotween
        if(b_used == false) //Activate UI
        {
            //Controllers change
            m_leftBaseController.SetActive(false);
            m_leftUiController.SetActive(true);

            m_rightBaseController.SetActive(false);
            m_rightUIController.SetActive(true);

            //Canvas
            m_canvasOptions.SetActive(true);
            b_used = true;
            m_audioSource.Play();
        }
        else //Desactivate UI
        {
            //Controllers change
            m_leftBaseController.SetActive(true);
            m_leftUiController.SetActive(false);

            m_rightBaseController.SetActive(true);
            m_rightUIController.SetActive(false);

            //Canvas
            m_canvasOptions.SetActive(false);
            b_used = false;
            m_audioSource.Play();
        }
    }
}
