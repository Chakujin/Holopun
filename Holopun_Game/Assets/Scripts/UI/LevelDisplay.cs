using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    public LevelData levelData;

    [SerializeField] private TextMeshProUGUI s_levelName;

    // Start is called before the first frame update
    void Start()
    {
        s_levelName.text = levelData.levelName; 
    }
}
