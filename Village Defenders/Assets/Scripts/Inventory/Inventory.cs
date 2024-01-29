using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour { 
public static Inventory instance;
public List<ScriptableVegetables> inventoryVegetables = new List<ScriptableVegetables>();
[SerializeField] private GameObject inventoryPanel;
[SerializeField] private GameObject shopPanel;
[SerializeField] private GameObject playerPanel;
[SerializeField] private GameObject farmingPanel;
[SerializeField] private GameObject enemiesUI;
[SerializeField] private GameObject playerButtonsPanel;
[SerializeField] private GameObject inventoryVegetableUI;
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

       public void OpenInventory() { 
        farmingPanel.SetActive(false);
        enemiesUI.SetActive(false);
        playerButtonsPanel.SetActive(false);
       feedNpcText.SetActive(false);
        inventoryPanel.SetActive(true);
       ShowInventory();
                     }
    public void CloseInventory()
{
    inventoryPanel.SetActive(false);
    shopPanel.SetActive(false);
    playerPanel.SetActive(true);
    farmingPanel.SetActive(true);
    enemiesUI.SetActive(false);
    feedNpcText.SetActive(false);
    playerButtonsPanel.SetActive(true);
}

    public void AddVegetableToInventory(ScriptableVegetables vegetable)
    {
        inventoryVegetables.Add(vegetable);
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject npc in npcs)
        {
            npc.GetComponent<NPCMorale>().npcVegetables.Add(vegetable);
            Debug.Log("Npc got the vegetable");

        }
    }
    private void Update()
    {
          
        
        if (Input.GetMouseButtonDown(0) && canFeedNPC)
            {
                RayCastFeedNPC();
            }
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
         //   inventorySlotClone.GetComponent<Vegetable>().vegetable = vegetable;
            inventorySlotClone.GetComponentInChildren<Button>().onClick.AddListener(() => UseVegetable());
       
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
            vegetable.isInInventory = true;
        }
        if (vegetable.veggieID == 1 && vegetable.quantity > 1)
        {
            GameObject tomatoInventoryObject = GameObject.Find("CabbageInventory");
            tomatoInventoryObject.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity +1 + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
        }
        if (vegetable.veggieID == 2 && vegetable.quantity == 1 && vegetable.isInInventory == false)
        {
            Debug.Log("Veggie is that veggie");
            GameObject inventorySlotClone = Instantiate(inventoryVegetableUI, inventoryUIPosition.position, Quaternion.identity);
            inventorySlotClone.name = "BananaInventory";
            inventorySlotClone.transform.SetParent(inventoryUIPosition);
            inventorySlotClone.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
            inventorySlotClone.GetComponentInChildren<Image>().sprite = vegetable.spriteImage;
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
            vegetable.isInInventory = true;
        }
        if (vegetable.veggieID == 3 && vegetable.quantity > 1)
        {
            GameObject tomatoInventoryObject = GameObject.Find("OrangeInventory");
            tomatoInventoryObject.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
        }
    }
}
public void UseVegetable()
{
    inventoryPanel.SetActive(false);
    feedNpcText.SetActive(true);
    canFeedNPC = true;
    Debug.Log("Use Vegetable");
}
private void RayCastFeedNPC()
{

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out hit, Mathf.Infinity, npcLayerMask))
    {
            foreach (ScriptableVegetables vegetable in inventoryVegetables)
            {
                Debug.Log("Clicked on NPC: " + hit.collider.gameObject.name);
                hit.collider.GetComponent<NPCMorale>().AddMorale(vegetable);
                hit.collider.GetComponent<NPC>().PlayMoraleAnimation();
                CloseInventory();
              //  inventoryVegetables.Remove(vegetable);
            }
               

    }
}
}