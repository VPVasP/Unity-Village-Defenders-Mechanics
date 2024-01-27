using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //speed time button 
    [SerializeField] private Button speedTimeButton;
    //bool to check if our button is being clicked
    [SerializeField] private bool isButtonBeingClicked;
   
    private void Update()
    {
        //if we click on it and the button can be clicked
        if (Input.GetMouseButtonDown(0) && speedTimeButton.interactable)
        {
            isButtonBeingClicked = true;
            Debug.Log("Button is being pressed");
        }
        //if we release the mouse button on it and the button can be clicked
        if (Input.GetMouseButtonUp(0) || !speedTimeButton.interactable)
        {
            isButtonBeingClicked = false;
            Time.timeScale = 1.0f;
            Debug.Log("Button is not being pressed");
        }
        //if the button is being clicked all the time
        if (isButtonBeingClicked)
        {
            Time.timeScale = 2.5f;
            Debug.Log("Button is being pressed all the time");
        }
    }
}
