using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrowVegetable : MonoBehaviour,IVegetable
{
    [Header("Growth Values")]
    [SerializeField] private float maxScale = 1f;
    [SerializeField] private float  growthRate = 0.1f;
    [SerializeField] private float currentScale = 0f;
    [SerializeField] private float timeLeft;

    [Header("Vegetables")]
    public ScriptableVegetables scriptableveg;
    [SerializeField] private GameObject growVegetableText;
    private GameObject growVegetablePanel;
    private string veggieName;
   [SerializeField] private Transform inventoryUIPosition;
    [Header("Audio")]
    [SerializeField] private AudioSource aud;
    [SerializeField] private AudioClip veggieSoundEffect;
    public GameObject inventoryPanel;
    private RaycastHit hit;
    private bool readytoHarvest = false;
    [SerializeField] float groundDistance = 0.6f; //the ground distance value
    public LayerMask mudMask; //layermask for the mud
    private void Start()
    {
        //setting up the UI
        Transform FarmingManagerUI = GameObject.Find("VegetableGrowingPanel").transform;
        //we instatiate the veggie panel clone and add the stuff we need to at it
        growVegetablePanel = Instantiate(growVegetableText, FarmingManagerUI.transform.position, Quaternion.identity);
        growVegetablePanel.transform.SetParent(FarmingManagerUI);
        veggieName = scriptableveg.name;
        //audio managment
        if (aud == null)
        {
            this.gameObject.AddComponent<AudioSource>();
        }

        aud = GetComponent<AudioSource>();
        aud.loop = false;
        aud.playOnAwake = false;
        mudMask = 1 << LayerMask.NameToLayer("Mud");
        gameObject.tag = "Vegetable";
    }
    #region growVeggie
    //function that handles the growth of our vegetable and the UI
    public void GrowTheVegetable()
    {
        if (currentScale < maxScale)
        {
            currentScale += growthRate * Time.deltaTime;
            currentScale = Mathf.Min(currentScale, maxScale);
            transform.localScale = Vector3.one * currentScale;
            timeLeft = Mathf.RoundToInt((maxScale - currentScale) / growthRate);
            growVegetablePanel.GetComponentInChildren<TextMeshProUGUI>().text = veggieName + " Time left: " + Mathf.Round(timeLeft).ToString();
        }
    }
    #endregion
    //bool to check if the veggie is ready to harvest
    public bool IsReadyToHarvest()
    {
        return timeLeft == 0;
    }
   
    //function that handles the harvesting of the vegggie
    public void Harvest()
    {

        if (IsReadyToHarvest())
        {
            ScriptableVegetables harvestedVegetable = scriptableveg;
            harvestedVegetable.quantity += 1;
            
            aud.clip = veggieSoundEffect;
            aud.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.position = new Vector3(gameObject.transform.position.z, gameObject.transform.position.y + 0.2f, gameObject.transform.position.z);
            Destroy(growVegetablePanel, 1.5f);
            Destroy(this.gameObject, 1.5f);
            Inventory.instance.AddVegetableToInventory(scriptableveg);
         
            
        }
    }

    private void Update()
    {



        inventoryUIPosition = Inventory.instance.inventoryUIPosition;
        
        //we grow the vegetable if not fully grown
        if (currentScale < maxScale)
        {
            GrowTheVegetable();
            growVegetablePanel.GetComponentInChildren<TextMeshProUGUI>().text = veggieName + " Time left: " + Mathf.Round(timeLeft).ToString();
        }
        //we update UI when ready to harvest
        if (timeLeft == 0)
        {
            growVegetablePanel.GetComponentInChildren<TextMeshProUGUI>().text = veggieName + " To Harvest Press Z";
            readytoHarvest = true;
        }
        //we harvest when it is ready
        if (readytoHarvest == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (!Inventory.instance.inventoryVegetables.Contains(scriptableveg))
                {
                    GameObject inventoryPanelClone = Instantiate(inventoryPanel, inventoryUIPosition.position, Quaternion.identity);
                    inventoryPanelClone.transform.SetParent(inventoryUIPosition);
                }
                else if (Inventory.instance.inventoryVegetables.Contains(scriptableveg))
                {
                    Debug.Log("vegetable already exists" + scriptableveg.name);
                }
                Harvest();
            }
        }
    }
   
}