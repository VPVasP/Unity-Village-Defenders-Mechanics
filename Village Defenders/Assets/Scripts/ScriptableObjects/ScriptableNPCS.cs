using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableNPCS", menuName = "NPC")]
public class ScriptableNPCS :ScriptableObject
{
    public string npcName;
    public int npcPrice;
    public Sprite spriteImage;
    public int npcID;
    public GameObject npcPrefab;
}
