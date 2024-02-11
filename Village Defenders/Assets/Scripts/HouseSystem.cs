using UnityEngine;
using UnityEngine.UI;

public class HouseSystem : MonoBehaviour
{
    private string wallTag = "House";
    [SerializeField] private LayerMask houseMask;
    public float houseHealth;
    public Slider houseHealthSlider;
    public GameObject[] enemies;
    private float distanceToEnemy;
    [SerializeField] private float minimumDistance;
    [SerializeField] private GameObject houseDestroyedEffect;
    private AudioSource aud;
    private void Start()
    {

        houseHealth = 100;
        houseHealthSlider = GetComponentInChildren<Slider>();
        houseHealthSlider.value = houseHealth;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (aud == null)
        {
            aud = gameObject.AddComponent<AudioSource>();
        }
        //audio 
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
        gameObject.tag = wallTag;
        houseMask = 1 << LayerMask.NameToLayer("House");
    }
    public void LoseHealth()
    {
        float loseRandomHealthValue = Random.Range(4, 6);
        houseHealth -= loseRandomHealthValue;
        houseHealthSlider.value = houseHealth;
    }
    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        houseHealth = Mathf.Clamp(houseHealth, 0f, 100f);
        if (houseHealth <= 0)
        {

            DestroyHouse();
            EnemiesSetNewTarget();
        }
        
    }


    private void DestroyHouse()
    {

        aud.Play();
        GameObject wallDestroyedEffectClone = Instantiate(houseDestroyedEffect, transform.position, Quaternion.identity);
        Destroy(wallDestroyedEffectClone);
        Destroy(gameObject,0.5f);
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