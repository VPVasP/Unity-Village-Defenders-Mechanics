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
    }

    private void Update()
    {
        Transform closestTarget = GetClosestTarget(targets);
        if (closestTarget != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, closestTarget.position);
            Debug.Log(distanceToTarget);
            if (distanceToTarget > minimumDistance)
            {
                MoveTowardsTarget(closestTarget.position);
                transform.LookAt(closestTarget);
            }
            if (distanceToTarget <= minimumDistance && distanceToTarget > attackDistance)
            {
                if (Time.time >= nextAttackTime)
                {
                    Debug.Log("Attack");
                    rb.velocity = Vector3.zero;
                   // closestTarget.GetComponent<WallSystem>().LoseHealth();
                    anim.SetTrigger("Attack");
                    nextAttackTime = Time.time + timeBetweenAttacks;
                }
                else
                {
                    Transform newTarget = GetClosestTarget(targets);
                    if (newTarget != null)
                    {

                        MoveTowardsTarget(newTarget.position);
                        transform.LookAt(newTarget);
                        minimumDistance = 6;
                        attackDistance = 2;

                    }

                }
            }
        }
    }
        private void MoveTowardsTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.AddForce(direction * movementSpeed);
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
}