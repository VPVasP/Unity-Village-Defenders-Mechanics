using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //speed time button 
    [SerializeField] private Button speedTimeButton;
    //bool to check if our button is being clicked
    [SerializeField] private bool isButtonBeingClicked;
   public void ClickedOnSpeedButton()
    {
        isButtonBeingClicked = true;
    }
    private void Update()
    {
        //if we click on it and the button can be clicked
        if (Input.GetMouseButtonDown(0) && !isButtonBeingClicked)
        {
            SpeedUpTime();
        }
        //if we release the mouse button on it and the button can be clicked
    else    if (Input.GetMouseButtonUp(0) &&isButtonBeingClicked)
        {

            ResetTime();
        }

    }
    private void SpeedUpTime()
    {
            isButtonBeingClicked = true;
            Time.timeScale = 2.5f;
            Debug.Log("Button is being pressed all the time");
        }
    
    private void ResetTime()
    {
        isButtonBeingClicked = false;
        Time.timeScale = 1.0f;
        Debug.Log("Button is not being pressed");
    }
}
