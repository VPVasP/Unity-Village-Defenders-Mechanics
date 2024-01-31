using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefencePlacementUI : MonoBehaviour
{
    [SerializeField] private DefencePlacement defencePlacement;
    public TextMeshProUGUI NumberText;
    private Canvas canvas;
    private Camera mainCam;
    public TextMeshProUGUI pressKeyText;
    private void Start()
    {
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
        NumberText.gameObject.SetActive(false);
    }
    public void UpdateUiIfPlaced()
    {
        NumberText.gameObject.SetActive(false);
        pressKeyText.gameObject.SetActive(true);
        pressKeyText.text = "The position with the number " + defencePlacement.keysToSpawn[0] + " is already occupied";

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
