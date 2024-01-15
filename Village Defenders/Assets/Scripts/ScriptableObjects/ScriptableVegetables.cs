using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableVegetables", menuName = "Vegetable")]
public class ScriptableVegetables : ScriptableObject
{
    public string veggieName;
    public int veggiePrice;
    public Sprite spriteImage;
    public int veggieID;
    public int veggieMoraleGiver;
    public GameObject veggiePrefab;
}
