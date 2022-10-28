using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowMachineState : MonoBehaviour
{
    //Machine States
    private MonoBehaviour CrossbowActualState;

    public MonoBehaviour CrossbowInicialState;
    public MonoBehaviour CrossbowEmptyState;
    public MonoBehaviour CrossbowChargedState;
    
    [SerializeField]
    private List<MonoBehaviour> _stateList;
    public GameObject arrow;

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
}
