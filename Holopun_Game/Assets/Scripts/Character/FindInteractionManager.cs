using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FindInteractionManager : MonoBehaviour
{
    [SerializeField] private XRDirectInteractor myDirectInteractor;
    [SerializeField] private XRRayInteractor myRayInteractor;

    [SerializeField] private bool b_Ray = false;

    // Start is called before the first frame update
    void Awake()
    {
        if(b_Ray == false)
        {
            myDirectInteractor.interactionManager = GameObject.FindGameObjectWithTag("InteractionManager")
            .GetComponent<XRInteractionManager>();
        }
        else
        {
            myRayInteractor.interactionManager = GameObject.FindGameObjectWithTag("InteractionManager")
            .GetComponent<XRInteractionManager>();
        }
    }
}
