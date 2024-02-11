using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{
    private string wallTag = "Wall";
    [SerializeField] private LayerMask wallMask;
    public float wallHealth;
    public Slider wallHealthSlider;
    public GameObject[] enemies;
    private float distanceToEnemy;
    [SerializeField] private float minimumDistance;
    [SerializeField] private GameObject wallDestroyedEffect;
    private AudioSource aud;
    [SerializeField] private AudioClip wallDestroyedSound;
    private string wallName;
    [SerializeField] private TextMeshProUGUI wallDownText;
    private bool isWallDownText;
    [SerializeField] private GameObject destroyedEffect;
    private void Start()
    {

        wallHealth = 100;
        wallHealthSlider = GetComponentInChildren<Slider>();
        wallHealthSlider.value = wallHealth;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (aud == null)
        {
            aud = gameObject.AddComponent<AudioSource>();
        }
        wallName = gameObject.name;
        wallDownText.text = "Wall was Destroyed " + wallName;
        wallDownText.gameObject.SetActive(false);
        //audio 
        aud = GetComponent<AudioSource>();
        aud.clip = wallDestroyedSound;
        aud.playOnAwake = false;
        aud.loop = false;

        gameObject.tag = wallTag;
        wallMask = 1 << LayerMask.NameToLayer("Wall");
    }
    public void LoseHealth()
    {
        float loseRandomHealthValue = Random.Range(4, 6);
        wallHealth -= loseRandomHealthValue;
        wallHealthSlider.value = wallHealth;
    }
    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        wallHealth = Mathf.Clamp(wallHealth, 0f, 100f);
        if (wallHealth <= 0)
        {

            DestroyCrystal();
            EnemiesSetNewTarget();
        }
        if (gameObject.transform.position == new Vector3(0f, -5f, 0f))
        {

            GameObject wallDestroyedEffectClone = Instantiate(wallDestroyedEffect, transform.position, Quaternion.identity);
            aud.Play();
            Destroy(wallDestroyedEffectClone, 0.5f);
        }
    }
    
    private void DestroyCrystal()
    {
       
        Destroy(gameObject, 2f);
        Debug.Log("Wall destroyed!");
    }

    private void EnemiesSetNewTarget()
    {
        foreach (GameObject enemy in enemies)
        {
            Transform Enemies = enemy.transform;
            if (Enemies != null)
            {
                enemy.GetComponent<EnemyMovement>().SetNewTarget();
                Debug.Log("NewTarget");
            }
        }
    }


}

