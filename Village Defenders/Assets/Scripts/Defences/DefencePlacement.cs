using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DefencePlacement : MonoBehaviour
{
    public static DefencePlacement instance;
    public bool hasBeenPlaced;
    public string[] keysToSpawn;
    [SerializeField] private bool hasPressedKeyTwice;
    [SerializeField] private int keyNumberPresses;
    [SerializeField] private DefencePlacementUI[] defencePlacementUI;
    public ScriptableDefences scriptableDefence;
    public bool canSpawnDefence;
    [SerializeField] private Vector3 defenceGameobjectRotation;
    [SerializeField] private AudioSource aud;
    [SerializeField] 
    private void Awake()
    {
        instance = this;
    }

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
        aud= GetComponent<AudioSource>();
        aud.playOnAwake = false;
    }


    private void Update()
    {
        if (!hasBeenPlaced)
        {
            foreach (string key in keysToSpawn)
            {
                if (Input.GetKeyDown(key) &&!hasBeenPlaced)
                {
                    aud.Play();
                    hasBeenPlaced = true;
                    this.enabled = false;
                    hasPressedKeyTwice = false;
                    keyNumberPresses += 1;
                    this.enabled = false;
                    GameObject scriptableDefenceClone = Instantiate(scriptableDefence.defencePrefab, transform.position, Quaternion.identity);
                    scriptableDefenceClone.transform.rotation = Quaternion.Euler(defenceGameobjectRotation);
                    scriptableDefenceClone.transform.SetParent(this.transform);

                    foreach (DefencePlacementUI defencePlacementUI in defencePlacementUI)
                    {

                        defencePlacementUI.pressKeyText.gameObject.SetActive(false);
                    }


                    break;
                }
                else if (hasBeenPlaced)
                {
                    this.enabled = false;
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