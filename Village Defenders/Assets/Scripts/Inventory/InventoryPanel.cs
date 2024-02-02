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
    [SerializeField] private int addedQuantity;
    [SerializeField] private GameObject inventory;
    private void Start()
    {
        button = GetComponentInChildren<Button>();
        veggieName.text = scriptableVegs.name;
        veggieImage.sprite = scriptableVegs.spriteImage;
        moraleGiverText.text = "Morale " + scriptableVegs.veggieMoraleGiver.ToString();
        quantityText.text = "Quantity " + scriptableVegs.quantity.ToString();
        button.onClick.AddListener(UseInventoryItem);
        addedQuantity = scriptableVegs.quantity;
        inventory = GameObject.Find("Inventory");
    }
    private void Update()
    {
        if (scriptableVegs.quantity != addedQuantity)
        {



            quantityText.text = "Quantity " + scriptableVegs.quantity.ToString();


           addedQuantity= scriptableVegs.quantity;
        }
        if (scriptableVegs.quantity==0)
        {
           inventory.gameObject.SetActive(true);
            Debug.Log("Gameobject Destroyed");
            Destroy(this.gameObject);
        }
    }
    
    public void UseInventoryItem()
    {
            scriptableVegs.quantity -= 1;
            Inventory.instance.FeedNPC(scriptableVegs.veggieID);
            Debug.Log("Used Item");
        
      

    }

}