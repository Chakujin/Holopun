using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerRunScript : MonoBehaviour
{
    [SerializeField] private InputActionReference eventButtonRun;
    [SerializeField] private ActionBasedContinuousMoveProvider m_continusMove;
    [SerializeField] private Slider m_runSlider;
    [SerializeField] private RectTransform m_sliderRecTrans;

    [SerializeField] private float f_runSpeed;
    private float f_currentSped;

    private float f_currentStamina;
    private const float f_maxStamina = 1;

    private float f_scaleY;

    private bool b_run = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get start scale
        f_scaleY = m_sliderRecTrans.localScale.y; 
        
        //Subscribe event button
        eventButtonRun.action.performed += RunPlayer;
      
        //Prepare Slider
        f_currentSped = m_continusMove.moveSpeed;

        //Slider
        m_runSlider.maxValue = f_maxStamina;        //Set max value slider
        m_runSlider.value = m_runSlider.maxValue;   //Set value slider

        f_currentStamina = m_runSlider.maxValue;    //Update Stamina start to max level

        m_runSlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        //Player Run
        if (b_run == true)
        {
            f_currentStamina -= 0.1f * Time.deltaTime;

            if (f_currentStamina <= 0)
            {
                StopRun();
            }
        }
        //Player Stop run
        else
        {
            if (f_currentStamina < f_maxStamina)
            {
                f_currentStamina += 0.2f * Time.deltaTime; //Add Stamina
            }
            else
            {
                f_currentStamina = f_maxStamina;
            }
        }
        m_runSlider.value = f_currentStamina; //Update Slider
    }

    private void RunPlayer(InputAction.CallbackContext context) //Called via input 
    {
        Debug.Log("Called Run");
        m_runSlider.gameObject.SetActive(true);
        if (b_run == false)
        {
            m_continusMove.moveSpeed = f_runSpeed;
            b_run = true;

            //RestartPos
            m_sliderRecTrans.DOScaleY(0, 0f);

            //StartAnimation
            m_sliderRecTrans.DOScaleY(f_scaleY, 0.75f).SetEase(Ease.OutQuart);
        }
        else
        {
            StopRun();
        }
    }

    private void StopRun()
    {
        b_run = false;
        m_continusMove.moveSpeed = f_currentSped;

        //StartAnimation
        m_sliderRecTrans.DOScaleY(0f, 0.5f).SetEase(Ease.OutQuart).OnComplete(() => m_runSlider.gameObject.SetActive(false));
    }
}
