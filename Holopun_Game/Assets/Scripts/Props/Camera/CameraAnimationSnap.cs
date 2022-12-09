using UnityEngine;
using DG.Tweening;

public class CameraAnimationSnap : MonoBehaviour
{
    [SerializeField] private GameObject m_textSnap;
    private RectTransform m_myRect;
    private Vector3 v_idlePos;
    [SerializeField] private Vector3 v_endPos;

    private void Start()
    {
        m_myRect = m_textSnap.GetComponent<RectTransform>();
        v_idlePos = m_myRect.localPosition;
        m_textSnap.SetActive(false);
    }

    public void AnimateSnap()
    {
        DOTween.Kill(m_myRect); //Stop all animations (Only use if player spam snaps)

        //Animation
        m_textSnap.SetActive(true);
        m_myRect.DOMoveZ(v_endPos.z,0.2f).SetEase(Ease.OutQuint).OnComplete(() => EndAnim());
    }

    private void EndAnim()
    {
        m_myRect.DOMoveZ(v_idlePos.z, 0f);
        m_textSnap.SetActive(false);
    }
}
