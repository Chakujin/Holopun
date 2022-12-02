using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class CutterMoriScript : MonoBehaviour
{
    [SerializeField] private Transform m_positionBox;
    [SerializeField] private Vector3 v_size;
    [SerializeField] private LayerMask m_interactableLayer;
    private bool b_taked = false;

    private GameObject playerGrab;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (b_taked == true)
        {
            Collider[] detectObject = Physics.OverlapBox(m_positionBox.position, v_size, Quaternion.identity, m_interactableLayer);

            foreach (Collider obj in detectObject)
            {
                IHiteable _interactable = obj.GetComponent<IHiteable>(); //Get the interface
                if (_interactable != null) //if the interface is not empty
                {
                    HitObject(_interactable);
                }
            }
        }
    }

    public void FindPlayerGrabMe(SelectEnterEventArgs args)
    {
        playerGrab = args.interactorObject.transform.root.gameObject;

        b_taked = true;
    }

    public void DropWeapon()
    {
        b_taked = false;
    }

    private void HitObject(IHiteable obj)
    {
        obj.Hited(playerGrab);  //pass player
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(m_positionBox.position, v_size);
    }
}
