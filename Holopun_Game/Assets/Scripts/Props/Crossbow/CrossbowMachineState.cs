using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CrossbowMachineState : MonoBehaviour
{
    //Machine States
    private MonoBehaviour CrossbowActualState;

    public MonoBehaviour CrossbowInicialState;
    public MonoBehaviour CrossbowEmptyState;
    public MonoBehaviour CrossbowChargedState;
    
    [SerializeField] private List<MonoBehaviour> _stateList;
    [SerializeField] private XRGrabInteractable m_myInteractable;
    
    [HideInInspector] public GameObject arrow;
    [HideInInspector] public GameObject playerGrab;

    // Start is called before the first frame update
    void Start()
    {
        //State Machine
        foreach (MonoBehaviour script in _stateList)
        {
            script.enabled = false;
        }

        ChangeState(CrossbowInicialState);
    }

    public void ChangeState(MonoBehaviour newState)
    {
        if (CrossbowActualState != null)
        {
            CrossbowActualState.enabled = false;
        }
        CrossbowActualState = newState;
        CrossbowActualState.enabled = true;
    }

    public void FindPlayerGrabMe(SelectEnterEventArgs args)
    {
        Debug.Log("Busco Player");
        playerGrab = args.interactorObject.transform.root.gameObject;
    }

    public void DesatachArrow()
    {
        arrow.GetComponent<ArrowScript>().ChangeArrowChargedCallback -= DesatachArrow;
        ChangeState(CrossbowEmptyState);
    }
}
