using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<ScriptableVegetables> inventoryVegetables = new List<ScriptableVegetables>();
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject playerPanel;
    [SerializeField] private GameObject farmingPanel;
    [SerializeField] private GameObject enemiesUI;
    [SerializeField] private GameObject playerButtonsPanel;
    //[SerializeField] private GameObject inventoryVegetableUI;
    [SerializeField] private GameObject timeSpeedText;
    public Transform inventoryUIPosition;

    [SerializeField] GameObject feedNpcText;
    private LayerMask npcLayerMask;
    [SerializeField] private bool canFeedNPC;
    public RaycastHit hit;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        inventoryPanel.SetActive(false);
        feedNpcText.SetActive(false);
        npcLayerMask = 1 << LayerMask.NameToLayer("NPC");
    }

    public void OpenInventory()
    {
        farmingPanel.SetActive(false);
        enemiesUI.SetActive(false);
        playerButtonsPanel.SetActive(false);
        feedNpcText.SetActive(false);
        inventoryPanel.SetActive(true);
        timeSpeedText.SetActive(false);
    }
    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        ShopUI.instance.ExitShop();
        playerPanel.SetActive(true);
        farmingPanel.SetActive(true);
        enemiesUI.SetActive(false);
        feedNpcText.SetActive(false);
        playerButtonsPanel.SetActive(true);
        timeSpeedText.SetActive(true);
    }

    public void AddVegetableToInventory(ScriptableVegetables vegetable)
    {
        inventoryVegetables.Add(vegetable);

    }
  
    public void FeedNPC(int id)
    {
   
            GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
            foreach (GameObject npc in npcs)
            {
                npc.GetComponent<NPCMorale>().AddMorale(inventoryVegetables[id]);
                npc.GetComponent<NPC>().PlayMoraleAnimation();
                Debug.Log("Npc got the vegetable");
            inventoryVegetables[id] -= 1;
            Invoke("DisableInventory", 0.2f);

        }
        }
    private void DisableInventory()
    {
        inventoryPanel.SetActive(false);
    }
    }

