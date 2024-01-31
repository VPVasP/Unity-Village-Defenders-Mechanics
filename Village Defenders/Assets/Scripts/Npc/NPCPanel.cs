using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCPanel : MonoBehaviour
{
    public ScriptableNPCS scriptableNpcs;
    public TextMeshProUGUI npcName;
    public Image npcImage;
    public TextMeshProUGUI npcPriceText;
    [SerializeField] Button button;
    private void Start()
    {
        button = GetComponentInChildren<Button>();
        npcName.text = scriptableNpcs.name;
        npcImage.sprite = scriptableNpcs.spriteImage;
        npcPriceText.text ="Price " + scriptableNpcs.npcPrice.ToString();
        button.onClick.AddListener(BuyItem);

    }
    public void BuyItem()
    {

        if (GameManager.instance.coins >= scriptableNpcs.npcPrice)
        {
            GameManager.instance.coins -= scriptableNpcs.npcPrice;
           NPCManager.instance.BuyNPC(scriptableNpcs.npcID);
            GameManager.instance.generalshopPanel.SetActive(false);
            Debug.Log("Bought item" + scriptableNpcs.name);
            GameManager.instance.UpdateCoinsUI();
            ShopUI.instance.ExitShop();
        }
    }

}
