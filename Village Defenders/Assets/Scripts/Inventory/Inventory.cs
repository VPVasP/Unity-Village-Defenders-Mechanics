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
    [SerializeField] private GameObject inventoryVegetableUI;
    [SerializeField] private GameObject timeSpeedText;
    [SerializeField] private Transform inventoryUIPosition;

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
        ShowInventory();
    }

    public void OpenInventory()
    {
        farmingPanel.SetActive(false);
        enemiesUI.SetActive(false);
        playerButtonsPanel.SetActive(false);
        feedNpcText.SetActive(false);
        inventoryPanel.SetActive(true);
        timeSpeedText.SetActive(false);
        ShowInventory();
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
    private void Update()
    {

        

    }

    private void ShowInventory()
    {

        foreach (ScriptableVegetables vegetable in inventoryVegetables)
        {
            if (vegetable.veggieID == 0 && vegetable.quantity == 1 && vegetable.isInInventory == false)
            {
                Debug.Log("Veggie is that veggie");
                GameObject inventorySlotClone = Instantiate(inventoryVegetableUI, inventoryUIPosition.position, Quaternion.identity);
                inventorySlotClone.name = "TomatoInventory";
                inventorySlotClone.transform.SetParent(inventoryUIPosition);
                inventorySlotClone.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
                inventorySlotClone.GetComponentInChildren<Image>().sprite = vegetable.spriteImage;
                inventorySlotClone.GetComponent<InventoryPanel>().scriptableVegs= vegetable;
              

                vegetable.isInInventory = true;
            }
            if (vegetable.veggieID == 0 && vegetable.quantity > 1)
            {
                GameObject tomatoInventoryObject = GameObject.Find("TomatoInventory");
                tomatoInventoryObject.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
            }
            if (vegetable.veggieID == 1 && vegetable.quantity == 1 && vegetable.isInInventory == false)
            {
                Debug.Log("Veggie is that veggie");
                GameObject inventorySlotClone = Instantiate(inventoryVegetableUI, inventoryUIPosition.position, Quaternion.identity);
                inventorySlotClone.name = "CabbageInventory";
                inventorySlotClone.transform.SetParent(inventoryUIPosition);
                inventorySlotClone.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
                inventorySlotClone.GetComponentInChildren<Image>().sprite = vegetable.spriteImage;
                inventorySlotClone.GetComponent<InventoryPanel>().scriptableVegs = vegetable;
                vegetable.isInInventory = true;
            }
            if (vegetable.veggieID == 1 && vegetable.quantity > 1)
            {
                GameObject tomatoInventoryObject = GameObject.Find("CabbageInventory");
                tomatoInventoryObject.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + 1 + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
            }
            if (vegetable.veggieID == 2 && vegetable.quantity == 1 && vegetable.isInInventory == false)
            {
                Debug.Log("Veggie is that veggie");
                GameObject inventorySlotClone = Instantiate(inventoryVegetableUI, inventoryUIPosition.position, Quaternion.identity);
                inventorySlotClone.name = "BananaInventory";
                inventorySlotClone.transform.SetParent(inventoryUIPosition);
                inventorySlotClone.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
                inventorySlotClone.GetComponentInChildren<Image>().sprite = vegetable.spriteImage;
                inventorySlotClone.GetComponent<InventoryPanel>().scriptableVegs = vegetable;
                vegetable.isInInventory = true;
            }
            if (vegetable.veggieID == 2 && vegetable.quantity > 1)
            {
                GameObject tomatoInventoryObject = GameObject.Find("BananaInventory");
                tomatoInventoryObject.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
            }
            if (vegetable.veggieID == 3 && vegetable.quantity == 1 && vegetable.isInInventory == false)
            {
                Debug.Log("Veggie is that veggie");
                GameObject inventorySlotClone = Instantiate(inventoryVegetableUI, inventoryUIPosition.position, Quaternion.identity);
                inventorySlotClone.name = "OrangeInventory";
                inventorySlotClone.transform.SetParent(inventoryUIPosition);
                inventorySlotClone.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
                inventorySlotClone.GetComponentInChildren<Image>().sprite = vegetable.spriteImage;
                inventorySlotClone.GetComponent<InventoryPanel>().scriptableVegs = vegetable;
                vegetable.isInInventory = true;
            }
            if (vegetable.veggieID == 3 && vegetable.quantity > 1)
            {
                GameObject tomatoInventoryObject = GameObject.Find("OrangeInventory");
                tomatoInventoryObject.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
            }
        }
    }
   
    public void FeedNPC(int id)
    {
   
            GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
            foreach (GameObject npc in npcs)
            {
                npc.GetComponent<NPCMorale>().AddMorale(inventoryVegetables[id]);
                npc.GetComponent<NPC>().PlayMoraleAnimation();
                Debug.Log("Npc got the vegetable");
               inventoryPanel.SetActive(false);



        }
        }

    }

