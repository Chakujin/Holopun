using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FindInteractionManager : MonoBehaviour
{
    [SerializeField] private XRDirectInteractor myInteractor;
    // Start is called before the first frame update
    void Awake()
    {
        myInteractor.interactionManager = GameObject.FindGameObjectWithTag("InteractionManager")
            .GetComponent<XRInteractionManager>();
    }
}
