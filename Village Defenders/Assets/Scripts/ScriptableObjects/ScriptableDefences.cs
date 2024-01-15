using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableDefences", menuName = "Defence")]
public class ScriptableDefences :ScriptableObject
{
    public string defenceName;
    public int defencePrice;
    public Sprite spriteImage;
    public int defenceID;
    public GameObject defencePrefab;
}
