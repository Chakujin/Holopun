using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    [Header("Data")]
    [HideInInspector] public LevelData levelData;
    [SerializeField] private TextMeshProUGUI s_levelName;
    [SerializeField] private Image bgImage;

    private SelectedPlayerManager m_selectedPlayer;
    private CharacterDisplay m_characterDisplay;

    // Start is called before the first frame update
    void Start()
    {
        m_selectedPlayer = GameObject.FindGameObjectWithTag("SelectedPlayer").GetComponent<SelectedPlayerManager>();
        m_characterDisplay = GameObject.FindGameObjectWithTag("CharacterDisplay").GetComponent<CharacterDisplay>();

        //Datas
        s_levelName.text = levelData.levelName;
        bgImage.sprite = levelData.bgImage;
    }

    public void PressSelect()
    {
        m_selectedPlayer.SetLevel(levelData.sceneLoad);
        m_characterDisplay.PassDatas(levelData.characters);
    }
}
