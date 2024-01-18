using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WallSystem : MonoBehaviour
{
    [SerializeField] private string wallTag;
    [SerializeField] private LayerMask wallMask;
    public float wallHealth;
    [SerializeField] private Slider wallHealthSlider;
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
    }
   public void LoseHealth()
    {
        wallHealth -= 5;
        wallHealthSlider.value = wallHealth;
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
