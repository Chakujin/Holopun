using UnityEngine;

public class SpawnLevels : MonoBehaviour
{
    [SerializeField] private LevelData[] m_dataList;
    [SerializeField] private GameObject m_levelChose;

    [SerializeField] private GameObject ScrollView;

    // Start is called before the first frame update
    void Start()
    {
        foreach(LevelData data in m_dataList) //Start put all datas
        {
            GameObject currentIns = Instantiate(m_levelChose,ScrollView.transform);
            LevelDisplay myData = currentIns.GetComponent<LevelDisplay>(); // Get script

            myData.levelData = data; //Pass data
        }
    }
}
