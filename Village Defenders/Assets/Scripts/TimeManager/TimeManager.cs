using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Button speedTimeButton;
    [SerializeField] private bool isButtonBeingClicked;
    [SerializeField] private TextMeshProUGUI timeSpeedText;
    private void Start()
    {
        isButtonBeingClicked = false;
        timeSpeedText.text = "Time Speed:Normal";
    }
    public void ClickedOnSpeedButton()
    {
        isButtonBeingClicked = !isButtonBeingClicked;

        if (isButtonBeingClicked)
        {
            SpeedUpTime();
        }
        else
        {
            ResetTime();
        }
    }

    private void SpeedUpTime()
    {
        Time.timeScale = 2.5f;
        timeSpeedText.text = "Time Speed:Double";
        Debug.Log("Time is sped up");
    }

    private void ResetTime()
    {
        Time.timeScale = 1.0f;
        timeSpeedText.text = "Time Speed:Normal";
        Debug.Log("Time is reset");
    }
}