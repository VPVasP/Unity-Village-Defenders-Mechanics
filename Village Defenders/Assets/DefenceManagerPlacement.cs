using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefenceManagerPlacement : MonoBehaviour
{

    public GameObject[] positions;
    public static DefenceManagerPlacement instance;
    public Color emptyPositionColor;
    public string[] keysToPress;
   [SerializeField] private TextMeshProUGUI pressKeyText;
    public bool canPressKey;
    private void Awake()
    {
        instance = this;
    }
    {
        pressKeyText.gameObject.SetActive(false);
        foreach (GameObject position in positions)
        {
            MeshRenderer meshRenderer = position.GetComponent<MeshRenderer>();
            position.AddComponent<PositionPlacement>();
            meshRenderer.material.color = Color.green;
        }
    }

    public void PickPosition()
    {
        foreach (GameObject position in positions)
        {
            position.GetComponent<PositionPlacement>().enabled = true;
            pressKeyText.gameObject.SetActive(true);
        }
    }
}