using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class SetGraphics : MonoBehaviour
{
    [SerializeField] private RenderPipelineAsset[] m_qualitylevels;
    [SerializeField] private TMP_Dropdown m_dropdown;

    // Start is called before the first frame update
    void Start()
    {
        m_dropdown.value = QualitySettings.GetQualityLevel();
    }

    public void ChangeLevel(int value)
    {
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = m_qualitylevels[value];
    }
}
