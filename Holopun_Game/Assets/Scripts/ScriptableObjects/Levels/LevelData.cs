using UnityEngine;

[CreateAssetMenu(fileName = "New Level Data", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public int sceneLoad;
    public Sprite bgImage;
    public CharacterData[] characters;
}
