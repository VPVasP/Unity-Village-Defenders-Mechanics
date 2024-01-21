using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class WallSystem : MonoBehaviour
{
    private string wallTag;
    [SerializeField] private LayerMask wallMask;
    public float wallHealth;
    [SerializeField] private Slider wallHealthSlider;
    public GameObject[] enemies;
    private float distanceToEnemy;
    [SerializeField] private float minimumDistance;
    [SerializeField] private GameObject wallDestroyedEffect;
    private AudioSource aud;
    [SerializeField] private AudioClip wallDestroyedSound;
    private string wallName;
    [SerializeField] private TextMeshProUGUI wallDownText;
    private bool isWallDownText;
    private void OnEnable()
    {
        gameObject.tag = wallTag;
        wallMask = 1 << LayerMask.NameToLayer("Wall");
    }
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
        if (wallHealth <= 0)
        {

            DestroyWall();
            EnemiesSetNewTarget();
        }
        if (gameObject.transform.position == new Vector3(0f, -5f, 0f))
        {

            GameObject wallDestroyedEffectClone = Instantiate(wallDestroyedEffect, transform.position, Quaternion.identity);
            aud.Play();
            Destroy(wallDestroyedEffectClone, 0.5f);
        }
    }
    //private IEnumerator RemoveWallTextEnumerator()
    //{
    //    yield return new WaitForSeconds(3f);
    //    wallDownText.gameObject.SetActive(false);
    //}

    private void DestroyWall()
    {
       
     //   wallDownText.gameObject.SetActive(true);
       // StartCoroutine(RemoveWallTextEnumerator());
        gameObject.transform.position += new Vector3(0f, -2.5f * Time.deltaTime, 0f);
        Destroy(gameObject, 3f);
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