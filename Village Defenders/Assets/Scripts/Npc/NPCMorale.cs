using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCMorale : MonoBehaviour
{
    [SerializeField] private Image moraleImage;
    [SerializeField] private Sprite[] moraleSprites;
    private bool isDead;
    private Slider moraleSlider;
    private float moraleMeter;
    private Animator anim;
    private void Start()
    {
        moraleMeter = 100;
        moraleSlider = GetComponentInChildren<Slider>();
        moraleImage.sprite = moraleSprites[0];
        anim = GetComponent<Animator>();
        moraleSlider.value =moraleMeter;
    }
    private void Update()
    {
        float moodLoss = Random.Range(3, 5);
        moraleMeter -= moodLoss * Time.deltaTime;
        moraleSlider.value = moraleMeter;
        if (moraleMeter <= 100 && !isDead)
        {
            moraleImage.sprite = moraleSprites[1];
            TextMeshProUGUI hungryText = moraleSlider.GetComponentInChildren<TextMeshProUGUI>();

            hungryText.text = "I feel very energized";
        }
        if (moraleMeter<=80 && !isDead)
        {
            moraleImage.sprite = moraleSprites[2];
            TextMeshProUGUI hungryText = moraleImage.GetComponentInChildren<TextMeshProUGUI>();

            hungryText.text = "I am starting to feel Hungry...";
        }
        if (moraleMeter <= 60 && !isDead)
        {
            moraleImage.sprite = moraleSprites[3];
            TextMeshProUGUI hungryText = moraleImage.GetComponentInChildren<TextMeshProUGUI>();

            hungryText.text = "I feel a bit weak....";
        }
        if (moraleMeter <= 40 && !isDead)
        {
            moraleImage.sprite = moraleSprites[4];
            TextMeshProUGUI hungryText = moraleImage.GetComponentInChildren<TextMeshProUGUI>();

            hungryText.text = "I need food....";
        }
        if (moraleMeter <= 20 && !isDead)
        {
            moraleImage.sprite = moraleSprites[4];
            TextMeshProUGUI hungryText = moraleImage.GetComponentInChildren<TextMeshProUGUI>();

            hungryText.text = "I feel like dying...";
        }
        if(moraleMeter<=0 & isDead)
        {
            isDead = true;
            moraleImage.sprite = moraleSprites[5];
            anim.SetTrigger("Dead");
            PopulationManager.instace.population -= 1;
            PopulationManager.instace.UpdatePopulationUI();
            Invoke("Dead", 4f);
        }
    }
    private void Dead()
    {
        Destroy(this.gameObject);
    }
}
