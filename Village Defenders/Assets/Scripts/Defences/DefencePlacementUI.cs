using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefencePlacementUI : MonoBehaviour
{
    public static DefencePlacementUI instance;
    [SerializeField] private DefencePlacement defencePlacement;
    public TextMeshProUGUI NumberText;
    private Canvas canvas;
    private Camera mainCam;
    public TextMeshProUGUI pressKeyText;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pressKeyText.text = "Press A key to spawn the defence";
        NumberText = GetComponentInChildren<TextMeshProUGUI>();
       // NumberText.transform.localScale = new Vector3(5, 5, 1);
        NumberText.transform.localRotation = Quaternion.Euler(0f,0f,0f);;
        canvas = GetComponentInChildren<Canvas>();

        defencePlacement = GetComponent<DefencePlacement>();
        NumberText.gameObject.SetActive(false);
        if (defencePlacement != null)
        {
            NumberText.text = "Press " + defencePlacement.keysToSpawn[0];
        }
        mainCam = Camera.main;
      canvas.worldCamera = mainCam;
      canvas.transform.localRotation = Quaternion.Euler(0f,0f, 0f);
    }
    public void UpdateUiIfNotPlaced()
    {
        NumberText.text = "";
        pressKeyText.gameObject.SetActive(false);
        pressKeyText.text = "Press A key to spawn the defence";
        NumberText.gameObject.SetActive(false);
    }
    public void UpdateUiIfPlaced()
    {
        NumberText.gameObject.SetActive(true);
        pressKeyText.gameObject.SetActive(true);
       

    }
    public void UpdateText()
    {
        pressKeyText.text = "Press A key to spawn the defence";
        //pressKeyText.gameObject.SetActive(true);
        NumberText.gameObject.SetActive(false);
    }
    private void Update()
    {
        canvas.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if (defencePlacement.hasBeenPlaced)
        {
            NumberText.text = "";
            NumberText.gameObject.SetActive(false);
        }
    }
}
