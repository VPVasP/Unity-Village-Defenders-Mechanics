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
    private void Start()
    {
        button = GetComponentInChildren<Button>();
        veggieName.text = scriptableVegs.name;
        veggieImage.sprite = scriptableVegs.spriteImage;
        moraleGiverText.text = "Morale " + scriptableVegs.veggieMoraleGiver.ToString();
        quantityText.text = "Quantity " + scriptableVegs.quantity.ToString();
        button.onClick.AddListener(UseInventoryItem);

    }
    public void UseInventoryItem()
    {
        Inventory.instance.FeedNPC(scriptableVegs.veggieID);
        Debug.Log("Used Item");
    }

}