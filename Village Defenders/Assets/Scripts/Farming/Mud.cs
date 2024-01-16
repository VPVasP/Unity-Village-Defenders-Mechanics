using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{
    [SerializeField] private string mudTag;
    [SerializeField] private LayerMask mudMask;
    public bool canBePlanted;
    private void OnEnable()
    {
        gameObject.tag = mudTag;
        mudMask = 1 << LayerMask.NameToLayer("Mud");
    }
    private void Start()
    {
        canBePlanted = true;
    }
    public bool CanBePlanted()
    {
        return canBePlanted;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Vegetable"))
        {
            canBePlanted = false;
            Debug.Log("Touching");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Vegetable"))
        {
            canBePlanted =true;
            Debug.Log("Left");
        }
    }
}