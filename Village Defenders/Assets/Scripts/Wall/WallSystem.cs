using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WallSystem : MonoBehaviour
{
    [SerializeField] private string wallTag;
    [SerializeField] private LayerMask wallMask;
    public float wallHealth;
    [SerializeField] private Slider wallHealthSlider;
    public GameObject[] enemies;
    private float distanceToEnemy;
    [SerializeField] private float minimumDistance;
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
    }
    public void LoseHealth()
    {
        wallHealth -= 5;
        wallHealthSlider.value = wallHealth;
        //foreach (GameObject enemy in enemies)
        //{
        //    distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);


        //    Debug.Log("DistanceToEnemy" + distanceToEnemy);
        //    if (distanceToEnemy < minimumDistance)
        //    {
        //        wallHealth -= 5;
        //        wallHealthSlider.value = wallHealth;
        //        enemy.GetComponent<EnemyMovement>().AttackTarget(this.transform.position);
        //    }

        //}
    }
    private void Update()
    {
        if(wallHealth <= 0) {

            DestroyWall();

        }
    }
    private void DestroyWall()
    {
        foreach (GameObject enemy in enemies)
        {
            Transform closestTarget = enemy.GetComponent<EnemyMovement>().GetClosestTarget(enemy.GetComponent<EnemyMovement>().targets);
            if (closestTarget != null)
            {
                enemy.GetComponent<EnemyMovement>().MoveTowardsTarget(closestTarget.position);
                Debug.Log("NewTarget");
            }
        }
            Debug.Log("Wall destroyed!");
        Destroy(gameObject,0.5f);

    }
}
