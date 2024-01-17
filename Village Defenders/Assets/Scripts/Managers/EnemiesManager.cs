using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesManager : MonoBehaviour
{   [Header("Texts")]
    [SerializeField] private TextMeshProUGUI totalEnemiesText;
    [SerializeField] private TextMeshProUGUI enemiesUpText;
    [SerializeField] private TextMeshProUGUI enemiesLeftText;
    [SerializeField] private TextMeshProUGUI enemiesRightText;
    [SerializeField] private TextMeshProUGUI enemiesDownText;
    [SerializeField] private TextMeshProUGUI timerText; //our text for the timer
    [SerializeField] private TextMeshProUGUI dayNightsText; //our text for the night
    [Header("DayNightCycle")]
    public Material[] SkyboxMaterials; //refrence to our skybox materials
    private float timer; ///our timer refrence
    [SerializeField] private int daysPassed = 1; //the days passed
    private string stringTimer = "Timer: "; //timer sting
    private string daysNightString = "Day "; //day string                                    //   public Transform directionalLight;
    [SerializeField] private bool isNight = false; //bool to check if it is night
    [Header("Enemies")]
    public GameObject[] enemies; //enemies gameobejct to be spawned
    [SerializeField] private Transform[] SpawnPositions; //our spawn positions transform
    private bool hasSpawnedEnemies = false; //bool to check if enemies have been spawned
    private string enemiesString = "Total Alive Enemies ";
    [Header("Audio")]
    [SerializeField] private AudioSource mainMusic;
    [SerializeField] private AudioClip mainMusicAudioClip;
    [SerializeField] private AudioClip battleMusicAudioClip;
    [SerializeField] private GameObject enemiesUI;
    private void Start()
    {
        RenderSettings.skybox = SkyboxMaterials[0]; //we set our skybox material array to 0 because it is day
        //we set our texts to false
        totalEnemiesText.gameObject.SetActive(false);
        enemiesUpText.gameObject.SetActive(false);
        enemiesLeftText.gameObject.SetActive(false);
        enemiesRightText.gameObject.SetActive(false);
        enemiesDownText.gameObject.SetActive(false);
        mainMusic.clip = mainMusicAudioClip;
        mainMusic.loop = true;
        mainMusic.playOnAwake = true;
        mainMusic.Play();
        enemiesUI.SetActive(false);
    }
    private void Update()
    {

        DayNightHandler();

    }
    private void EnemySpawner(int enemiesToBeSpawned)
    {
        if (enemies.Length > 0)
        {
            int totalEnemiesSpawned = 0;

            for (int i = 0; i < SpawnPositions.Length; i++)
            {
                for (int j = 0; j < enemiesToBeSpawned; j++)
                {
                    GameObject enemy = enemies[Random.Range(0, enemies.Length)];

                    float offsetX = Random.Range(-30f, 30f);
                    float offsetY = Random.Range(0f, 0f);
                    float offsetZ = Random.Range(-40f, 40f);
                    Vector3 randomSpawnPoint = new Vector3(offsetX, offsetY, offsetZ);
                    Instantiate(enemy, SpawnPositions[i].position + randomSpawnPoint, Quaternion.identity);

                    totalEnemiesSpawned++;
                }

              
            }

            enemiesUI.SetActive(true);
            totalEnemiesText.gameObject.SetActive(true);
            enemiesUpText.gameObject.SetActive(true);
            enemiesLeftText.gameObject.SetActive(true);
            enemiesRightText.gameObject.SetActive(true);
            enemiesDownText.gameObject.SetActive(true);

            totalEnemiesText.text = enemiesString + totalEnemiesSpawned.ToString();
            enemiesUpText.text = "Enemies On Up Side " + enemiesToBeSpawned.ToString();
            enemiesLeftText.text = "Enemies On Left Side " + enemiesToBeSpawned.ToString();
            enemiesRightText.text = "Enemies On Right Side " + enemiesToBeSpawned.ToString();
            enemiesDownText.text = "Enemies On Down Side " + enemiesToBeSpawned.ToString();
        }
    }
    private void UpdateTimer(float currentTime)
    {
        //we convert seconds to minutes
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        //we update the ui text to display the seconds and the minutes
        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void DayNightHandler()
    {
        //switch day based on the days passed
        switch (daysPassed)
        {
            case 1:
                //we update the days night text
                dayNightsText.text = daysNightString + daysPassed.ToString();
                //we check for the days completion 
                timer += Time.deltaTime;
                float maxTime = 10;
                if (timer < 0)
                {
                    timer = 0;
                }
                if (timer >= maxTime)
                {
                    daysPassed += 1;
                    Debug.Log("DayOneFinished");
                    timer = 0;
                }
                //update the timer display UI
                UpdateTimer(timer);


                break;
            case 2:
                dayNightsText.text = daysNightString + daysPassed.ToString();
                timer += Time.deltaTime;
                float maximumTime = 20;

                if (timer < 0)
                {
                    timer = 0;
                }
                if (timer >= maximumTime)
                {
                    daysPassed += 1;
                    Debug.Log("Day2Finished");
                    timer = 0;

                }
                UpdateTimer(timer);


                break;
            case 3:
                //now that night happens we update the daysnighttext
                mainMusic.clip = battleMusicAudioClip;
                mainMusic.Play();
                dayNightsText.text = daysNightString + daysPassed.ToString();
                Debug.Log("NightHappens");
                isNight = true; //we check if it is night 
                RenderSettings.skybox = SkyboxMaterials[1]; //we set our skybox material to 1 because it is night
                if (!hasSpawnedEnemies)
                {
                    int randomEnemies = Random.Range(8, 10);
                    EnemySpawner(randomEnemies);
                   
                    hasSpawnedEnemies = true; //we set the bool to true that it has spawned enemies 
                }
                break;


            case 4:
                totalEnemiesText.gameObject.SetActive(false);
                break;

            default:

                break;
        }
    }
}
