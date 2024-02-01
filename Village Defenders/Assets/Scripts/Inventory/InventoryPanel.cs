using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public List<ScriptableVegetables> vegetables;
    [SerializeField] Button button;
    private bool isClicked = false;

    private void Start()
    {
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(UseVegetable);
    }
    public void UseVegetable()
    {
        if (vegetables.Count > 0)
        {
            Inventory.instance.UseVegetable();
            isClicked = true;
            Debug.Log("Vegetable clicked");
        }

    }


}