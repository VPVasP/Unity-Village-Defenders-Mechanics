using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VeggiePanel : MonoBehaviour
{
    public ScriptableVegetables scriptableVegs;
    public TextMeshProUGUI veggieName;
    public Image veggieImage;
    public TextMeshProUGUI veggiePriceText;
    [SerializeField] Button button;
    private void Start()
    {
        button = GetComponentInChildren<Button>();
        veggieName.text = scriptableVegs.name;
        veggieImage.sprite = scriptableVegs.spriteImage;
        veggiePriceText.text = scriptableVegs.veggiePrice.ToString();
        button.onClick.AddListener(BuyItem);

    }
    public void BuyItem()
    {

        if (GameManager.instance.coins >= scriptableVegs.veggiePrice)
        {
            GameManager.instance.coins -= scriptableVegs.veggiePrice;
            FarmingManager.instance.PlantVegetable(scriptableVegs.veggieID);
            GameManager.instance.generalshopPanel.SetActive(false);
            GameManager.instance.veggiesScriptable.Add(scriptableVegs);
            Debug.Log("Bought item" + scriptableVegs.name);
            ShopUI.instance.ExitShop();
        }
    }

}

