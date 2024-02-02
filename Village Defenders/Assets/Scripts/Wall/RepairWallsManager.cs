using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RepairWallsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] walls;
    private void Update()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }
    public void Restore20Health()
    {
        if (GameManager.instance.coins >= 20)
        {
            foreach (GameObject wall in walls)
            {
                if (wall.GetComponent<WallSystem>().wallHealth < 100)
                {
                    wall.GetComponent<WallSystem>().wallHealth += 20;
                    wall.GetComponent<WallSystem>().wallHealthSlider.value = wall.GetComponent<WallSystem>().wallHealth;
                    ShopUI.instance.ExitShop();
                    GameManager.instance.UpdateCoinsUI();
                }
            }

        }
        else
        {
            Debug.Log("Not enough Money");
        }

    }
    public void Restore40Health()
    {
        if (GameManager.instance.coins >= 40)
        {
            foreach (GameObject wall in walls)
            {
                if (wall.GetComponent<WallSystem>().wallHealth < 100)
                {
                    wall.GetComponent<WallSystem>().wallHealth += 40;
                    wall.GetComponent<WallSystem>().wallHealthSlider.value = wall.GetComponent<WallSystem>().wallHealth;
                    ShopUI.instance.ExitShop();
                    GameManager.instance.UpdateCoinsUI();
                }
               
            }

        }
        else
        {
            Debug.Log("Not enough Money");
        }
    }
    public void Restore60Health()
    {
        if (GameManager.instance.coins >= 60)
        {
            foreach (GameObject wall in walls)
            {
                if (wall.GetComponent<WallSystem>().wallHealth < 100)
                {
                    wall.GetComponent<WallSystem>().wallHealth += 60;
                    wall.GetComponent<WallSystem>().wallHealthSlider.value = wall.GetComponent<WallSystem>().wallHealth;
                    ShopUI.instance.ExitShop();
                    GameManager.instance.UpdateCoinsUI();
                }
            }

        }
        else
        {
            Debug.Log("Not enough Money");
        }
    }
    public void Restore80Health()
    {
        if (GameManager.instance.coins >= 80)
        {
            foreach (GameObject wall in walls)
            {
                if (wall.GetComponent<WallSystem>().wallHealth < 100)
                {
                    wall.GetComponent<WallSystem>().wallHealth += 80;
                    wall.GetComponent<WallSystem>().wallHealthSlider.value = wall.GetComponent<WallSystem>().wallHealth;
                    ShopUI.instance.ExitShop();
                    GameManager.instance.UpdateCoinsUI();
                }
            }

        }
        else
        {
            Debug.Log("Not enough Money");
        }
    }
    public void Restore100Health()
    {
        if (GameManager.instance.coins >= 100)
        {
            foreach (GameObject wall in walls)
            {
                if (wall.GetComponent<WallSystem>().wallHealth < 100)
                {
                    wall.GetComponent<WallSystem>().wallHealth = 100;
                    wall.GetComponent<WallSystem>().wallHealthSlider.value = wall.GetComponent<WallSystem>().wallHealth;
                    ShopUI.instance.ExitShop();
                    GameManager.instance.UpdateCoinsUI();
                }
            }

        }
        else
        {
            Debug.Log("Not enough Money");
        }
    }
}
