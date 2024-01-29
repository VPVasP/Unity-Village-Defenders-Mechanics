using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCMorale : MonoBehaviour
{
    [SerializeField] private Image moraleImage;
    [SerializeField] private Sprite[] moraleSprites;
    [SerializeField] private bool isDead;
    private Slider moraleSlider;
    public float moraleMeter;
    [SerializeField] private Animator anim;
    [SerializeField] private NPC npcMovement;
    [SerializeField] private GameObject fill;
    public List<ScriptableVegetables> npcVegetables = new List<ScriptableVegetables>();
    private void Start()
    {
        moraleMeter = 100;
        anim = GetComponent<Animator>();
        moraleSlider = GetComponentInChildren<Slider>();
        moraleImage.sprite = moraleSprites[0];
        moraleSlider.value =moraleMeter;
        isDead = false;
    }
    private void Update()
    {
        float moodLoss = Random.Range(3, 5);
        moraleMeter -= moodLoss * Time.deltaTime;
        moraleSlider.value = moraleMeter;
        if (moraleMeter <= 100 && !isDead)
        {
            moraleImage.sprite = moraleSprites[0];
            TextMeshProUGUI hungryText = moraleSlider.GetComponentInChildren<TextMeshProUGUI>();
            moraleSlider.GetComponentInChildren<Image>().color = Color.green;
            fill.GetComponentInChildren<Image>().color = Color.green;
            hungryText.text = "I feel very energized";
        }
        if (moraleMeter<=80 && !isDead)
        {
            moraleImage.sprite = moraleSprites[1];
            TextMeshProUGUI hungryText = moraleSlider.GetComponentInChildren<TextMeshProUGUI>();
            moraleSlider.GetComponentInChildren<Image>().color = Color.yellow;
            fill.GetComponentInChildren<Image>().color = Color.yellow;
            hungryText.text = "I am starting to feel Hungry...";
        }
        if (moraleMeter <= 60 && !isDead)
        {
            moraleImage.sprite = moraleSprites[2];
            TextMeshProUGUI hungryText = moraleSlider.GetComponentInChildren<TextMeshProUGUI>();
            moraleSlider.GetComponentInChildren<Image>().color = Color.blue;
            fill.GetComponentInChildren<Image>().color = Color.blue;
            hungryText.text = "I feel a bit weak....";
        }
        if (moraleMeter <= 40 && !isDead)
        {
            moraleImage.sprite = moraleSprites[3];
            TextMeshProUGUI hungryText = moraleSlider.GetComponentInChildren<TextMeshProUGUI>();
            moraleSlider.GetComponentInChildren<Image>().color = Color.gray;
            fill.GetComponentInChildren<Image>().color = Color.gray;
            hungryText.text = "I need food....";
        }
        if (moraleMeter <= 20 && !isDead)
        {
            moraleImage.sprite = moraleSprites[4];
            TextMeshProUGUI hungryText = moraleSlider.GetComponentInChildren<TextMeshProUGUI>();
            moraleSlider.GetComponentInChildren<Image>().color = Color.black;
            fill.GetComponentInChildren<Image>().color = Color.black;
            hungryText.text = "I feel like dying...";
        }
        if (moraleMeter <= 0 && !isDead)
        {
            isDead = true;
            moraleImage.sprite = moraleSprites[4];
            anim.SetTrigger("Dead");
            npcMovement.enabled = false;
            PopulationManager.instace.population -= 1;
            PopulationManager.instace.UpdatePopulationUI();
            Invoke("Dead", 4f);
            Debug.Log("Dead");
        }
    }
    public void AddMorale(ScriptableVegetables vegetable)
    {
        moraleMeter += vegetable.veggieMoraleGiver;
        Debug.Log(moraleMeter);
    }
 
    public void Dead()
    {
        Destroy(this.gameObject);
    }
}
