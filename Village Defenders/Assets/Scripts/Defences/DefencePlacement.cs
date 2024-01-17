using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefencePlacement : MonoBehaviour
{
    public bool hasBeenPlaced;
    public GameObject objectToInstantiate;
    public string[] keysToSpawn;
    public TextMeshProUGUI pressKeyText;
    private void Start()
    {
        hasBeenPlaced = false;
        this.enabled = false;
    }

    private void Update()
    {
        if (!hasBeenPlaced)
        {
            foreach (string key in keysToSpawn)
            {
                if (Input.GetKeyDown(key))
                {
                    Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                    hasBeenPlaced = true;
                    this.enabled = false;
                    pressKeyText.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}