using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public static ShopUI instance;
    [SerializeField] private GameObject generalShopPanel;
    [SerializeField] private GameObject veggiesShopPanel;
    [SerializeField] private GameObject npcsShopPanel;
    [SerializeField] private GameObject defencesShopPanel;
    [SerializeField] private GameObject playerPanel;
    [SerializeField] private GameObject EnemiesUI;
    [SerializeField] private GameObject farmingPanel;
    [SerializeField] private GameObject playerButtosnPanel;
    [SerializeField] private GameObject defenceShopPanelToSpawn;
    public GameObject repairWallsPanel;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        generalShopPanel.SetActive(false);
        veggiesShopPanel.SetActive(false);
        npcsShopPanel.SetActive(false);
        defencesShopPanel.SetActive(false);
        playerPanel.SetActive(true);
        EnemiesUI.SetActive(false);
        farmingPanel.SetActive(true);
        playerButtosnPanel.SetActive(true);
        repairWallsPanel.SetActive(false);
    }
    public void EnableVeggiesShopPanel()
    {
        generalShopPanel.SetActive(false);
        veggiesShopPanel.SetActive(true);
        npcsShopPanel.SetActive(false);
        defencesShopPanel.SetActive(false);
        playerPanel.SetActive(false);
        EnemiesUI.SetActive(false);
        farmingPanel.SetActive(false);
        playerButtosnPanel.SetActive(false);
        repairWallsPanel.SetActive(false);
    }
    public void EnableNPCSShopPanel()
    {
        generalShopPanel.SetActive(false);
        veggiesShopPanel.SetActive(false);
        npcsShopPanel.SetActive(true);
        defencesShopPanel.SetActive(false);
        playerPanel.SetActive(false);
        EnemiesUI.SetActive(false);
        farmingPanel.SetActive(false);
        playerButtosnPanel.SetActive(false);
        repairWallsPanel.SetActive(false); ;
    }
    public void EnableDefencesShopPanel()
    {
        generalShopPanel.SetActive(false);
        veggiesShopPanel.SetActive(false);
        npcsShopPanel.SetActive(false);
        defencesShopPanel.SetActive(true);
        playerPanel.SetActive(false);
        EnemiesUI.SetActive(false);
        farmingPanel.SetActive(false);
        playerButtosnPanel.SetActive(false);
        defenceShopPanelToSpawn.SetActive(true);
        repairWallsPanel.SetActive(false);
    }
    public void EnableRepairWallsPanel()
    {
        generalShopPanel.SetActive(false);
        veggiesShopPanel.SetActive(false);
        npcsShopPanel.SetActive(false);
        defencesShopPanel.SetActive(false);
        playerPanel.SetActive(false);
        EnemiesUI.SetActive(false);
        farmingPanel.SetActive(false);
        playerButtosnPanel.SetActive(false);
        defenceShopPanelToSpawn.SetActive(false);
        repairWallsPanel.SetActive(true);
    }
    public void ReturnOrEnableGeneralShopPanel()
    {
        generalShopPanel.SetActive(true);
        veggiesShopPanel.SetActive(false);
        npcsShopPanel.SetActive(false);
        defencesShopPanel.SetActive(false);
        playerPanel.SetActive(false);
        EnemiesUI.SetActive(false);
        farmingPanel.SetActive(false);
        playerButtosnPanel.SetActive(false);
        repairWallsPanel.SetActive(false);
    }
    public void ExitShop()
    {
        generalShopPanel.SetActive(false);
        veggiesShopPanel.SetActive(false);
        npcsShopPanel.SetActive(false);
        defencesShopPanel.SetActive(false);
        playerPanel.SetActive(true);
        EnemiesUI.SetActive(false);
        farmingPanel.SetActive(true);
        playerButtosnPanel.SetActive(true);
        repairWallsPanel.SetActive(false);
    }
}
