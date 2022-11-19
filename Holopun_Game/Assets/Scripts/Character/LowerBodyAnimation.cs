using UnityEngine;

public class LowerBodyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField][Range(0, 1)] private float f_leftFootPosisitionWeight;
    [SerializeField][Range(0, 1)] private float f_rigthFootPosisitionWeight;

    [SerializeField][Range(0, 1)] private float f_leftFootRotationWeight;
    [SerializeField][Range(0, 1)] private float f_rigthFootRotationWeight;

    [SerializeField] private Vector3 f_footOffset;

    [SerializeField] private Vector3 v_raycastLeftOffset;
    [SerializeField] private Vector3 v_raycastRightOffset;

    private void OnAnimatorIK(int layerIndex)
    {
        Vector3 leftFootPosition = animator.GetIKPosition(AvatarIKGoal.LeftFoot);
        Vector3 rightFootPosition = animator.GetIKPosition(AvatarIKGoal.RightFoot);

        RaycastHit hitLeftFoot;
        RaycastHit hitRightFoot;

        bool isLeftDown = Physics.Raycast(leftFootPosition + v_raycastLeftOffset, Vector3.down, out hitLeftFoot);
        bool isRightDown = Physics.Raycast(rightFootPosition + v_raycastRightOffset, Vector3.down, out hitRightFoot);

        CalculateLeftFoot(isLeftDown, hitLeftFoot);
        CalculateRightFoot(isRightDown,hitRightFoot);
    }

    private void CalculateLeftFoot( bool isLeftDown, RaycastHit hitLeftFoot)
    {
        if (isLeftDown)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, f_leftFootPosisitionWeight);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, hitLeftFoot.point + f_footOffset);

            Quaternion leftFootRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hitLeftFoot.normal), hitLeftFoot.normal);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, f_leftFootPosisitionWeight);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRotation);
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
        }
    }
    private void CalculateRightFoot(bool isRightDown, RaycastHit hitRightFoot)
    {
        if (isRightDown)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, f_rigthFootPosisitionWeight);
            animator.SetIKPosition(AvatarIKGoal.RightFoot, hitRightFoot.point + f_footOffset);

            Quaternion rightFootRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hitRightFoot.normal), hitRightFoot.normal);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, f_rigthFootPosisitionWeight);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRotation);
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
        }
    }
}
