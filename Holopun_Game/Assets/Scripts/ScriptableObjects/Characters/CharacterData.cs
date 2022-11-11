using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    public GameObject playerIngame;
    public GameObject characterSelect;
    public string playerName;
}
