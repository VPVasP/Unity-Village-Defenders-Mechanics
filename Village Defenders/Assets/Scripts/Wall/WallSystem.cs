using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WallSystem : MonoBehaviour
{
    [SerializeField] private string wallTag;
    [SerializeField] private LayerMask wallMask;
    public float wallHealth;
    private void OnEnable()
    {
        gameObject.tag = wallTag;
        wallMask = 1 << LayerMask.NameToLayer("Wall");
    }
    private void Start()
    {
        wallHealth = 100;
    }
   public void LoseHealth()
    {
        wallHealth -= 5;
    }
    private void Update()
    {
        if(wallHealth <= 0) {
            DestroyWall();

        }
    }
    private void DestroyWall()
    {
        Debug.Log("Wall destroyed!");
        Destroy(gameObject);

    }
}
