using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefencesPanel : MonoBehaviour
{
    public ScriptableDefences scriptableDefence;
    public TextMeshProUGUI defenceName;
    public Image defenceImage;
    public TextMeshProUGUI veggiePriceText;
    [SerializeField] Button button;
    public  DefencePlacement[] defencePlacement;
    private void Start()
    {
        button = GetComponentInChildren<Button>();
        defenceName.text ="Item Name "+ scriptableDefence.name;
        defenceImage.sprite = scriptableDefence.spriteImage;
        veggiePriceText.text ="Price "+ scriptableDefence.defencePrice.ToString();
        defencePlacement = FindObjectsOfType<DefencePlacement>();
        
      
        button.onClick.AddListener(BuyItem);

    }
    private void Update()
    {
       
    }

    public void BuyItem()
    {

        if (GameManager.instance.coins >= scriptableDefence.defencePrice)
        {
            GameManager.instance.coins -= scriptableDefence.defencePrice;
            GameManager.instance.generalshopPanel.SetActive(false);
            Debug.Log("Bought item" + scriptableDefence.name);
            GameManager.instance.UpdateCoinsUI();
            ShopUI.instance.ExitShop();
            DefenceManagerPlacement.instance.PickPosition();
            foreach (var defence in defencePlacement)
            {
                defence.scriptableDefence = scriptableDefence;
            }

        }
    }
}
