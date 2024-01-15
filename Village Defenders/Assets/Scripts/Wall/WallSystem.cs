using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WallSystem : MonoBehaviour
{
    [SerializeField] private string wallTag;
    [SerializeField] private LayerMask wallMask;
    private float wallHealth;
    [SerializeField] private GameObject canvasPrefab;
    private void OnEnable()
    {
        gameObject.tag = wallTag;
        wallMask = 1 << LayerMask.NameToLayer("Wall");
    }
    private void Start()
    {
        wallHealth = 100;
    }
}
