using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
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
    [SerializeField] private bool canUseRaycast;
    [SerializeField] private bool usedRaycast;
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
        inventoryPanel.SetActive(true);
        shopPanel.SetActive(false);
        playerPanel.SetActive(false);
        farmingPanel.SetActive(false);
        enemiesUI.SetActive(false);
        playerButtonsPanel.SetActive(false);
        feedNpcText.SetActive(false);
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
    }
    private void Update()
    {
    

        if (Input.GetMouseButtonDown(0) && canUseRaycast && !usedRaycast)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, npcLayerMask))
            {
                Debug.Log("Added Morale to npc " + hit.collider.gameObject.name + hit.collider.gameObject.GetComponent<NPCMorale>().moraleMeter);
              //  hit.collider.gameObject.GetComponent<NPCMorale>().AddMorale(0)
                hit.collider.gameObject.GetComponent<NPC>().PlayMoraleAnimation();
                feedNpcText.gameObject.SetActive(false);
                usedRaycast = true;
                CloseInventory();
            }
        }
    }

    private void ShowInventory()
    {
        foreach (Transform child in inventoryUIPosition)
        {
            Destroy(child.gameObject);
        }


        foreach (ScriptableVegetables vegetable in inventoryVegetables)
        {
            CreateInventorySlot(vegetable);
        }
    }
    private void CreateInventorySlot(ScriptableVegetables vegetable)
    {
        GameObject inventorySlotClone =Instantiate(inventoryVegetableUI, inventoryUIPosition.position, Quaternion.identity);
        if (inventorySlotClone != null)
        {
            if (vegetable.quantity == 1 && !vegetable.isInInventory)
            {
                InstantiateInventorySlot(vegetable, inventorySlotClone);

                vegetable.isInInventory = true;
            }
            else if (vegetable.quantity > 1 && vegetable.isInInventory)
            {
                TextMeshProUGUI textMesh = inventorySlotClone.GetComponentInChildren<TextMeshProUGUI>();
                textMesh.text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
            }
        }
    }
    private void InstantiateInventorySlot(ScriptableVegetables vegetable, GameObject inventorySlotObject)
    {
        GameObject inventorySlotClone = Instantiate(inventorySlotObject, inventoryUIPosition.position, Quaternion.identity);
        inventorySlotClone.name = vegetable.name;
        inventorySlotClone.transform.SetParent(inventoryUIPosition);
        inventorySlotClone.GetComponentInChildren<TextMeshProUGUI>().text = " Vegetable Name " + vegetable.name + " Vegetable Quantity " + vegetable.quantity + " Vegetable Morale Giver " + vegetable.veggieMoraleGiver;
        inventorySlotClone.GetComponentInChildren<Image>().sprite = vegetable.spriteImage;
        InventoryPanel inventoryPanel = inventorySlotClone.GetComponent<InventoryPanel>();
        inventoryPanel.vegetables.Add(vegetable);
    }

    public void UseVegetable()
    {
        inventoryPanel.SetActive(false);
        feedNpcText.SetActive(true);
        canFeedNPC = true;
        Debug.Log("Use Vegetable");
        canUseRaycast = true;

    }

 
    }


