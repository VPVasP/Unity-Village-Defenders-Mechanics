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
    [SerializeField] private AudioSource aud;
    [SerializeField] private AudioClip villageMusicAudioClip;
    [SerializeField] private AudioClip battleMusicAudioClip;
    [SerializeField] private GameObject enemiesUI;
    [SerializeField] private GameObject directionalLight;
    [SerializeField] private Color[] directionalLightColors;

    [SerializeField] private int totalEnemiesAlive;
    private int totalEnemiesSpawned = 0;
    public static EnemiesManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        RenderSettings.skybox = SkyboxMaterials[0]; //we set our skybox material array to 0 because it is day
        //we set our texts to false
        totalEnemiesText.gameObject.SetActive(false);
        enemiesUpText.gameObject.SetActive(false);
        enemiesLeftText.gameObject.SetActive(false);
        enemiesRightText.gameObject.SetActive(false);
        enemiesDownText.gameObject.SetActive(false);
        //audio
        if (aud == null)
        {
            aud = gameObject.AddComponent<AudioSource>();
        }
        aud =GetComponent<AudioSource>();
        aud.clip = villageMusicAudioClip;
        aud.loop = true;
        aud.Play();

        enemiesUI.SetActive(false);
        directionalLight.GetComponent<Light>().color = directionalLightColors[0];
    }
    private void Update()
    {

        DayNightHandler();

    }
    private void EnemySpawner(int enemiesToBeSpawned)
    {
        if (enemies.Length > 0)
        {
            aud.clip = battleMusicAudioClip;
            aud.Play();
            RenderSettings.skybox = SkyboxMaterials[1]; //we set our skybox material to 0 because it is day
            directionalLight.GetComponent<Light>().color = directionalLightColors[1];
            StartCoroutine(SpawnEnemiesWithDelay(enemiesToBeSpawned));
        }
    }
    private IEnumerator SpawnEnemiesWithDelay(int enemiesToBeSpawned)
    {
        float spawnDelay = 0.5f;

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
                totalEnemiesAlive++;
                Debug.Log(totalEnemiesAlive);;
                totalEnemiesText.gameObject.SetActive(true);
             
                yield return new WaitForSeconds(spawnDelay); 
            }
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
    public void EnemyDeathCount()
    {
        if (totalEnemiesAlive > 0)
        {
            totalEnemiesAlive--;
            totalEnemiesText.text = enemiesString + totalEnemiesText.ToString();
            Debug.Log(totalEnemiesAlive +"Enemies Killed");
        }
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
                dayNightsText.text = daysNightString + daysPassed.ToString();
                isNight = true;

                if (!hasSpawnedEnemies)
                {
                    int randomEnemies = Random.Range(3, 5);
                    EnemySpawner(randomEnemies);
                    hasSpawnedEnemies = true;
                }

                timer += Time.deltaTime;

                if (totalEnemiesAlive == 0)
                {
                    daysPassed += 1;
                    dayNightsText.text = daysNightString + daysPassed.ToString();
                    isNight = false;
                    RenderSettings.skybox = SkyboxMaterials[0];
                    directionalLight.GetComponent<Light>().color = directionalLightColors[0];

                    // Reset the audio clip to village music

                }

                totalEnemiesText.gameObject.SetActive(false);
                UpdateTimer(timer);
                break;

        

            case 4:
                timer += Time.deltaTime;
                float maximumTimeCase4 = 30;

                if (timer < 0)
                {
                    timer = 0;
                }
                if (timer >= maximumTimeCase4)
                {
                    daysPassed += 1;
                    Debug.Log("Day4Finished");
                    timer = 0;

                }
                UpdateTimer(timer); 
                RenderSettings.skybox = SkyboxMaterials[0]; //we set our skybox material to 0 because it is day
                directionalLight.GetComponent<Light>().color = directionalLightColors[0];
                aud.clip = villageMusicAudioClip;
                aud.Play();
                totalEnemiesText.gameObject.SetActive(false);
                break;
            case 5:
                dayNightsText.text = daysNightString + daysPassed.ToString();
                isNight = true;

                if (!hasSpawnedEnemies)
                {
                    int randomEnemies = Random.Range(3,8);
                    EnemySpawner(randomEnemies);
                    hasSpawnedEnemies = true;
                }

                timer += Time.deltaTime;

                if (totalEnemiesAlive == 0)
                {
                    daysPassed += 1;
                    dayNightsText.text = daysNightString + daysPassed.ToString();
                    isNight = false;
                    RenderSettings.skybox = SkyboxMaterials[0];
                    directionalLight.GetComponent<Light>().color = directionalLightColors[0];

                    // Reset the audio clip to village music

                }

                totalEnemiesText.gameObject.SetActive(false);
                UpdateTimer(timer);
                break;
            case 6:
                timer += Time.deltaTime;
                float maximumTimeCase6 = 25;

                if (timer < 0)
                {
                    timer = 0;
                }
                if (timer >= maximumTimeCase6)
                {
                    daysPassed += 1;
                    Debug.Log("Day6Finished");
                    timer = 0;

                }
                UpdateTimer(timer);
                RenderSettings.skybox = SkyboxMaterials[0]; //we set our skybox material to 0 because it is day
                directionalLight.GetComponent<Light>().color = directionalLightColors[0];
                aud.clip = villageMusicAudioClip;
                aud.Play();
                totalEnemiesText.gameObject.SetActive(false);
                break;
            case 7:
                dayNightsText.text = daysNightString + daysPassed.ToString();
                isNight = true;

                if (!hasSpawnedEnemies)
                {
                    int randomEnemies = Random.Range(3, 8);
                    EnemySpawner(randomEnemies);
                    hasSpawnedEnemies = true;
                }

                timer += Time.deltaTime;

                if (totalEnemiesAlive == 0)
                {
                    daysPassed += 1;
                    dayNightsText.text = daysNightString + daysPassed.ToString();
                    isNight = false;
                    RenderSettings.skybox = SkyboxMaterials[0];
                    directionalLight.GetComponent<Light>().color = directionalLightColors[0];

                    // Reset the audio clip to village music

                }

                totalEnemiesText.gameObject.SetActive(false);
                UpdateTimer(timer);
                break;
            default:

                break;
        }
    }
}
