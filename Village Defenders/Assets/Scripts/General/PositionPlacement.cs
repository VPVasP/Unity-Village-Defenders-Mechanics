using TMPro;
using UnityEngine;

public class PositionPlacement : MonoBehaviour
{
    public bool hasBeenPlaced;
    public GameObject objectToInstantiate;
    public string keyToSpawn;
    private TextMeshProUGUI pressKeyText;
    [SerializeField]  private Rigidbody rb;
    private void Start()
    {
        hasBeenPlaced = false;
        this.enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        if (rb == null)
        {
          rb=  gameObject.AddComponent<Rigidbody>();
        }
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        pressKeyText = GetComponentInChildren<TextMeshProUGUI>();
        pressKeyText.text = keyToSpawn;
    }

    private void Update()
    {
        if (!hasBeenPlaced)
        {
          
                if (Input.GetKeyDown(keyToSpawn))
                {
                    Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                    hasBeenPlaced = true;
                    this.enabled = false;
                    pressKeyText.gameObject.SetActive(false);
                }
            }
        }
    }
