using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Shop")]
    public int coins = 100;
    [SerializeField] private GameObject[] VeggiePanels;
    [SerializeField] private GameObject[] NPCPanels;
    [SerializeField] private GameObject[] defencesPanels;
    public GameObject generalshopPanel;
    [SerializeField] private GameObject veggiesShopPanel;
    [SerializeField] private GameObject NpcsShopPanel;
    [SerializeField] private GameObject defencesShopPanel;
    [SerializeField] private TextMeshProUGUI coinsText;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        foreach (GameObject panelPrefab in VeggiePanels)
        {
            GameObject veggiesGameobjectPanel = Instantiate(panelPrefab, veggiesShopPanel.transform);
            veggiesGameobjectPanel.transform.localPosition = Vector3.zero;
        }
        foreach (GameObject NpcPrefabPanel in NPCPanels)
        {
            GameObject NpcsGameobjectPanel = Instantiate(NpcPrefabPanel, NpcsShopPanel.transform);
            NpcsGameobjectPanel.transform.localPosition = Vector3.zero;
        }
        foreach (GameObject defencesPrefabPanel in defencesPanels)
        {
            GameObject defencesGameobjectPanel = Instantiate(defencesPrefabPanel,defencesShopPanel.transform);
            defencesGameobjectPanel.transform.localPosition = Vector3.zero;
        }
    }

    private void Start()
    {
        generalshopPanel.SetActive(false);
        veggiesShopPanel.SetActive(false);
        NpcsShopPanel.SetActive(false);
        defencesShopPanel.SetActive(false);

        coinsText.text = "Coins: " + coins.ToString();
    }
    public void UpdateCoinsUI()
    {
        coinsText.text = "Coins: " + coins.ToString();
    }
    public void EnemyDeathAward(int enemyAward)
    {
        coins += enemyAward;
        coinsText.text = "Coins: " + coins.ToString();
    }
}
