using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject settingsMenuUI;
    private AudioSource aud;
    [SerializeField] private AudioClip hoverMouseSound;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
        aud.loop = false;
    }
    public void StartGame()
    {
        aud.Play();
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }
    public void LoadSettingsMenu()
    {
        aud.Play();
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);

    }
    public void QuitGame()
    {
        aud.Play();
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        aud.PlayOneShot(hoverMouseSound);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       
    }
}

