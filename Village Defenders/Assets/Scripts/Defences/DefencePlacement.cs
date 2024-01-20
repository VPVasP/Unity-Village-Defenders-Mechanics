using TMPro;
using UnityEngine;

public class DefencePlacement : MonoBehaviour
{
    public bool hasBeenPlaced;
    public GameObject objectToInstantiate;
    public string[] keysToSpawn;
    [SerializeField] private bool hasPressedKeyTwice;
    [SerializeField] private int keyNumberPresses;
    [SerializeField] private DefencePlacementUI[] defencePlacementUI;


    private void OnEnable()
    {
        defencePlacementUI = FindObjectsOfType<DefencePlacementUI>();
        foreach (DefencePlacementUI defencePlacementUI in defencePlacementUI)
        {

            defencePlacementUI.NumberText.gameObject.SetActive(true);
        }

    }
    private void OnDisable()
    {

        defencePlacementUI = FindObjectsOfType<DefencePlacementUI>();
        foreach (DefencePlacementUI defencePlacementUI in defencePlacementUI)
        {

            defencePlacementUI.NumberText.gameObject.SetActive(false);
        }

    }
    private void Start()
    {
        hasBeenPlaced = false;
        this.enabled = false;
        keyNumberPresses = 0;
        keyNumberPresses += 1;
       

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
                    hasPressedKeyTwice = false;
                    keyNumberPresses += 1;
                    this.enabled = false;
                    foreach (DefencePlacementUI defencePlacementUI in defencePlacementUI)
                    {

                        defencePlacementUI.pressKeyText.gameObject.SetActive(false);
                    }


                    break;
                }
            }

        }
        else if (hasBeenPlaced && !hasPressedKeyTwice)
        {
            foreach (string key in keysToSpawn)
            {
                if (Input.GetKeyDown(key))
                {
                    hasPressedKeyTwice = true;
                    keyNumberPresses += 1;
                    this.enabled = false;
                    foreach (DefencePlacementUI defencePlacementUI in defencePlacementUI)
                    {

                        defencePlacementUI.pressKeyText.gameObject.SetActive(false);
                    }



                    break;
                }
            }
     
        }
      

        
    }
}