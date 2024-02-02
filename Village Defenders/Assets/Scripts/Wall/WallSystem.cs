using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class WallSystem : MonoBehaviour
{
    private string wallTag ="Wall";
    [SerializeField] private LayerMask wallMask;
    public float wallHealth;
    public  Slider wallHealthSlider;
    public GameObject[] enemies;
    private float distanceToEnemy;
    [SerializeField] private float minimumDistance;
    [SerializeField] private GameObject wallDestroyedEffect;
    private AudioSource aud;
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
               //audio 
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
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

            DestroyWall();
            EnemiesSetNewTarget();
        }
        if (gameObject.transform.position == new Vector3(0f, -5f, 0f))
        {

            GameObject wallDestroyedEffectClone = Instantiate(wallDestroyedEffect, transform.position, Quaternion.identity);
       
            Destroy(wallDestroyedEffectClone, 1f);
        }
    }
 

    private void DestroyWall()
    {

        aud.Play();
        GameObject wallDestroyedEffectClone = Instantiate(wallDestroyedEffect, transform.position, Quaternion.identity);
        //gameObject.transform.position += new Vector3(0f, -2.5f * Time.deltaTime, 0f);
        Destroy(gameObject, 4f);
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