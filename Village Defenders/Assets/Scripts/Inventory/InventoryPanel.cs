using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public ScriptableVegetables scriptableVegs;
    public TextMeshProUGUI veggieName;
    public Image veggieImage;
    public TextMeshProUGUI moraleGiverText;
    public TextMeshProUGUI quantityText;
    [SerializeField] Button button;
    private int addedQuantity;
    private void Start()
    {
        button = GetComponentInChildren<Button>();
        veggieName.text = scriptableVegs.name;
        veggieImage.sprite = scriptableVegs.spriteImage;
        moraleGiverText.text = "Morale " + scriptableVegs.veggieMoraleGiver.ToString();
        quantityText.text = "Quantity " + scriptableVegs.quantity.ToString();
        button.onClick.AddListener(UseInventoryItem);
        addedQuantity = scriptableVegs.quantity;
    }
    private void Update()
    {
        if (scriptableVegs.quantity != addedQuantity)
        {



            quantityText.text = "Quantity " + scriptableVegs.quantity.ToString();


           addedQuantity= scriptableVegs.quantity;
        }
    }

    public void UseInventoryItem()
    {
        Inventory.instance.FeedNPC(scriptableVegs.veggieID);
        Inventory.instance.inventoryVegetables.Remove(scriptableVegs);
        Debug.Log("Used Item");
    }

}