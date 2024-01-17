using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;
    public List<ScriptableVegetables> inventoryVegetables = new List<ScriptableVegetables>();
    [SerializeField] private TextMeshProUGUI inventoryText;
    [SerializeField] private Image inventoryImage;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject playerPanel;
    [SerializeField] private GameObject farmingPanel;
    [SerializeField] private GameObject enemiesUI;
    [SerializeField] private GameObject playerButtonsPanel;
    [SerializeField] private GameObject inventoryVegetableUI;
    [SerializeField] private Transform inventoryUIPosition;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        inventoryPanel.SetActive(false);
    }
    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        shopPanel.SetActive(false);
        playerPanel.SetActive(false);
        farmingPanel.SetActive(false);
        enemiesUI.SetActive(false);
        playerButtonsPanel.SetActive(false);
    }
    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        shopPanel.SetActive(false);
        playerPanel.SetActive(true);
        farmingPanel.SetActive(true);
        enemiesUI.SetActive(false);
        playerButtonsPanel.SetActive(true);
    }
    private void Update()
    {
        enemiesUI.SetActive(false);
        ShowInventory();
    }
    public void AddVegetableToInventory(ScriptableVegetables vegetable){
       inventoryVegetables.Add(vegetable);
    }
  
   private void ShowInventory()
    {

      

        foreach (ScriptableVegetables vegetables in inventoryVegetables)
        {
            if (vegetables.veggieID == 0 && vegetables.quantity==1)
            {
                GameObject inventoryUIClone = Instantiate(inventoryVegetableUI, inventoryUIPosition.position, Quaternion.identity);
                inventoryUIClone.transform.SetParent(inventoryUIPosition);
                inventoryUIClone.GetComponentInChildren<TextMeshProUGUI>().text = "Vegetable Name: " + vegetables.name + " Quantity: " + vegetables.quantity.ToString() + " Morale: " + vegetables.veggieMoraleGiver.ToString();
                inventoryUIClone.GetComponentInChildren<Image>().sprite = vegetables.spriteImage;
            }
            if (vegetables.veggieID == 1 && vegetables.quantity == 1)
            {
                GameObject inventoryUIClone = Instantiate(inventoryVegetableUI, inventoryUIPosition.position, Quaternion.identity);
                inventoryUIClone.transform.SetParent(inventoryUIPosition);
                inventoryUIClone.GetComponentInChildren<TextMeshProUGUI>().text = "Vegetable Name: " + vegetables.name + " Quantity: " + vegetables.quantity.ToString() + " Morale: " + vegetables.veggieMoraleGiver.ToString();
                inventoryUIClone.GetComponentInChildren<Image>().sprite = vegetables.spriteImage;
            }
                if (vegetables.veggieID == 2 && vegetables.quantity == 1)
                {
                    GameObject inventoryUIClone = Instantiate(inventoryVegetableUI, inventoryUIPosition.position, Quaternion.identity);
                    inventoryUIClone.transform.SetParent(inventoryUIPosition);
                    inventoryUIClone.GetComponentInChildren<TextMeshProUGUI>().text = "Vegetable Name: " + vegetables.name + " Quantity: " + vegetables.quantity.ToString() + " Morale: " + vegetables.veggieMoraleGiver.ToString();
                    inventoryUIClone.GetComponentInChildren<Image>().sprite = vegetables.spriteImage;
                }
            if (vegetables.veggieID == 3 && vegetables.quantity == 1)
            {
                GameObject inventoryUIClone = Instantiate(inventoryVegetableUI, inventoryUIPosition.position, Quaternion.identity);
                inventoryUIClone.transform.SetParent(inventoryUIPosition);
                inventoryUIClone.GetComponentInChildren<TextMeshProUGUI>().text = "Vegetable Name: " + vegetables.name + " Quantity: " + vegetables.quantity.ToString() + " Morale: " + vegetables.veggieMoraleGiver.ToString();
                inventoryUIClone.GetComponentInChildren<Image>().sprite = vegetables.spriteImage;
            }
        }
    }
}
