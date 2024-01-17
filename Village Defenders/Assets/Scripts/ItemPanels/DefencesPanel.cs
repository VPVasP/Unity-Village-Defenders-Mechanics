using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefencesPanel : MonoBehaviour
{
    public ScriptableDefences scriptableDefences;
    public TextMeshProUGUI defenceName;
    public Image defenceImage;
    public TextMeshProUGUI veggiePriceText;
    [SerializeField] Button button;
    private void Start()
    {
        button = GetComponentInChildren<Button>();
        defenceName.text = scriptableDefences.name;
        defenceImage.sprite = scriptableDefences.spriteImage;
        veggiePriceText.text = scriptableDefences.defencePrice.ToString();
        button.onClick.AddListener(BuyItem);

    }
    public void BuyItem()
    {

        if (GameManager.instance.coins >= scriptableDefences.defencePrice)
        {
            GameManager.instance.coins -= scriptableDefences.defencePrice;
            FarmingManager.instance.PlantVegetable(scriptableDefences.defenceID);
            GameManager.instance.generalshopPanel.SetActive(false);
            Debug.Log("Bought item" + scriptableDefences.name);
            GameManager.instance.UpdateCoinsUI();
            ShopUI.instance.ExitShop();
            DefenceManagerPlacement.instance.PickPosition();
        }
    }
}
