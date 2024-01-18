using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcMoraleGiver : MonoBehaviour
{
    public GameObject[] NPCS;
    private Button button;
    [SerializeField] private ScriptableVegetables veggie;
    private void Start()
    {
        NPCS = GameObject.FindGameObjectsWithTag("NPC");

        button.onClick.AddListener(BuyItem);

    }
    public void BuyItem()
    {
        if (PopulationManager.instace.population > 0 && NPCS.Length > 0)
        {

        }
        else
        {
            Debug.Log("Cant feed the NPC Because no npcs exist");
        }

    }
}
