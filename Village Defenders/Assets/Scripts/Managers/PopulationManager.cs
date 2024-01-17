using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopulationManager : MonoBehaviour
{
    public static PopulationManager instace;
    public  int population;
    [SerializeField] private TextMeshProUGUI populationText;
    private void Awake()
    {
        instace = this;
    }
    private void Start()
    {
        populationText.text = "Current Village Population " + population.ToString();
    }
    public void UpdatePopulationUI()
    {
        populationText.text = "Current Village Population " + population.ToString();
    }
}

