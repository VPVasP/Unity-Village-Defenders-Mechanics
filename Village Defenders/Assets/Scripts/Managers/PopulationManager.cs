using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopulationManager : MonoBehaviour
{
    public static PopulationManager instace;
    [SerializeField] private int population;
    [SerializeField] private TextMeshProUGUI populationText;
    private void Awake()
    {
        instace = this;
    }
    private void Start()
    {
        populationText.text = "Current Village Population " + population.ToString();
    }
    public void UpdatePopulationStats()
    {
        populationText.text = "Current Village Population " + population.ToString();
    }
}

