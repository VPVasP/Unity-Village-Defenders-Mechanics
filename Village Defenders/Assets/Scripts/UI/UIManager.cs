using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    int UILayer;
    private Vector3 originalButtonSize;
    private GameObject mouseOverButton;
    [SerializeField] private AudioSource aud;
    private bool hasPlayedAud = false;
    private void Start()
    {
        UILayer = LayerMask.NameToLayer("Button");
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
    }

    private void Update()
    {
        GameObject buttonUnderMouse = MouseUnderButtonGameobject();

        if (buttonUnderMouse != null && buttonUnderMouse != mouseOverButton)
        {
           
            originalButtonSize = buttonUnderMouse.transform.localScale;
            hasPlayedAud = false;
        }

        if (IsPointerOverUIElement())
        {
            ButtonScaling(1.2f);
            if (!hasPlayedAud)
            {
                aud.Play();
                hasPlayedAud= true;
            }
        }
        else
        {
           
            if (mouseOverButton != null)
            {
                ButtonScaling(1.0f);
            }
        }

        mouseOverButton = buttonUnderMouse;
    }

    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }

    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults)
    {
        for (int index = 0; index < eventSystemRaycastResults.Count; index++)
        {
            RaycastResult curRaycastResult = eventSystemRaycastResults[index];
            if (curRaycastResult.gameObject.layer == UILayer)
                return true;
        }

        return false;
    }

    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }

    private void ButtonScaling(float buttonScale)
    {
        GameObject button = mouseOverButton;
        if (button != null)
        {
            button.transform.localScale = originalButtonSize * buttonScale;
        }
    }

    private GameObject MouseUnderButtonGameobject()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (RaycastResult result in raycastResults)
        {
            if (result.gameObject.layer == UILayer)
            {
                return result.gameObject;
            }
        }

        return null;
    }
}