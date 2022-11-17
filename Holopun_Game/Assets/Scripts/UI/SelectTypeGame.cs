using UnityEngine;

public class SelectTypeGame : MonoBehaviour
{
    [SerializeField] private GameObject m_singlePlayerCanvas;
    [SerializeField] private RectTransform m_levelRectTransform; //Only used for animation
    [SerializeField] private RectTransform m_characterRectTransform; //Only used for animation
    // [SerializeField] private GameObject m_multiPlayerCanvas;
    
    [SerializeField] private GameObject m_choseTypeCanvas;

    private void Start()
    {
        CanvasAnimation.CanvasMainAnimIn(this.gameObject,1,3);
    }

    public void PressSinglePlayer()
    {
        //Animations
        CanvasAnimation.CanvasMainAnimOut(this.gameObject, 0, 2);
        CanvasAnimation.CanvasSingleplayerIn(m_levelRectTransform);
        CanvasAnimation.CanvasSingleplayerIn(m_characterRectTransform);

        m_singlePlayerCanvas.SetActive(true);
        m_choseTypeCanvas.SetActive(false);
    }

    public void PressMultiplayer()
    {
        //Hay que montarlo
    }
}
