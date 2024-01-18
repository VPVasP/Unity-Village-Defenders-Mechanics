using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] targets;
    private Rigidbody rb;
    [Header("Values")]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float minimumDistance;
    private Transform currentTarget;
    [Header("Attack Values")]
    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private float nextAttackTime;
    [Header("Audio")]
    private AudioSource aud;
    [SerializeField] private AudioClip[] enemyAudios;
    private Animator anim;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private LayerMask groundMask;
    private float groundDistance = 0.6f;
    [SerializeField] private bool isGrounded;
    private void Start()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Wall");
        targets = new Transform[targetObjects.Length];

        for (int i = 0; i < targetObjects.Length; i++)
        {
            targets[i] = targetObjects[i].transform;
        }

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        if(aud == null)
        {
            aud = gameObject.AddComponent<AudioSource>();
        }
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
        aud.loop = false;

        anim= GetComponent<Animator>();

        gameObject.tag = "Enemy";
        groundMask = 1 << LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        Transform closestTarget = GetClosestTarget(targets);
        isGrounded = isGroundedBool();
        if (closestTarget != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, closestTarget.position);
          //  Debug.Log(distanceToTarget);
            if (distanceToTarget > minimumDistance &&isGroundedBool())
            {
               MoveTowardsTarget(closestTarget.position);
               RotateEnemy(closestTarget.position);
             
            }
            if (distanceToTarget <= minimumDistance && distanceToTarget > attackDistance &&isGroundedBool())
            {
                if (Time.time >= nextAttackTime)
                {
                    Debug.Log("Attack");
                    rb.velocity = Vector3.zero;
                    closestTarget.GetComponent<WallSystem>().LoseHealth();
                    anim.SetTrigger("Attack");
                    nextAttackTime = Time.time + timeBetweenAttacks;
                }
                anim.SetBool("isGrounded", isGrounded);

            }
            }
        }
    
        private void MoveTowardsTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.AddForce(direction * movementSpeed);
    }
    private void RotateEnemy(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }
    private Transform GetClosestTarget(Transform[] objects)
    {
        Transform bestTarget = null;
        float closestDistance = float.MaxValue;
        Vector3 currentPosition = transform.position;

        foreach (Transform currentObject in objects)
        {
            Vector3 differenceToTarget = currentObject.position - currentPosition;
            float distanceToTarget = differenceToTarget.sqrMagnitude;

            if (distanceToTarget < closestDistance)
            {
                closestDistance = distanceToTarget;
                bestTarget = currentObject;
            }
        }

        return bestTarget;
    }
    public void EnemyDeath()
    {
    GameObject deathEffectClone = Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        movementSpeed=0;
        Destroy(deathEffectClone, 0.8f);
        Destroy(gameObject, 1f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, minimumDistance);
    }
    bool isGroundedBool()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance, groundMask);
    }
}