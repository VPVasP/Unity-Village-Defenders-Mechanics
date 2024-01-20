using TMPro;
using UnityEngine;

public class DefencePlacement : MonoBehaviour
{
    public bool hasBeenPlaced;
    public GameObject objectToInstantiate;
    public string[] keysToSpawn;
    public TextMeshProUGUI pressKeyText;
    [SerializeField] private bool hasPressedKeyTwice;
    [SerializeField] private int keyNumberPresses;
    private void Start()
    {
        hasBeenPlaced = false;
        this.enabled = false;
        keyNumberPresses = 0;
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
                    hasPressedKeyTwice = false;
                    keyNumberPresses += 1;
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
                    pressKeyText.gameObject.SetActive(true);
                    pressKeyText.text = "The position with the number " + key + " is already occupied";
                    break;
                }
            }
     
        }
    }
}