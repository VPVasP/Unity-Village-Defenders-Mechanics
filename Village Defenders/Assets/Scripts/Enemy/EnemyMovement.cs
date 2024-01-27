using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> targets;
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
        targets = new List<Transform>();

        foreach (var targetObject in targetObjects)
        {
            targets.Add(targetObject.transform);
        }

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        if (aud == null)
        {
            aud = gameObject.AddComponent<AudioSource>();
        }

        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
        aud.loop = false;

        anim = GetComponent<Animator>();

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

            if (distanceToTarget > minimumDistance && isGroundedBool())
            {
                MoveTowardsTarget(closestTarget.position);
                RotateEnemy(closestTarget.position);
            }

            if (distanceToTarget < minimumDistance && isGroundedBool())
            {
                     AttackTarget(closestTarget.transform.position);
           }

            foreach (var target in targets)
            {
                if (target.GetComponent<WallSystem>().wallHealth <= 0)
                {
                    targets.Remove(target);
                    Debug.Log("Target Removed");
                }
            }
        }
        else
        {
            SetNewTarget();
        }
        if (targets.Count == 0)
        {
            Debug.Log("End Game");
        }
    }
    public void MoveTowardsTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.AddForce(direction * movementSpeed);
        anim.SetBool("isRunning", true);
    }
    private void RotateEnemy(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }
     public void AttackTarget(Vector3 targetPosition){
        Transform closestTarget = GetClosestTarget(targets);
        if (Time.time >= nextAttackTime && closestTarget != null)
            {
                Debug.Log("Attack");
                rb.velocity = Vector3.zero;

                anim.SetBool("isRunning", false);
                anim.SetTrigger("Attack");
                nextAttackTime = Time.time + timeBetweenAttacks;
            closestTarget.GetComponent<WallSystem>().LoseHealth();
            }

      
       
            anim.SetBool("isGrounded", isGrounded);
        }


    public Transform GetClosestTarget(List<Transform> objects)
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
    public void SetNewTarget()
    {
        Transform newTarget = GetClosestTarget(targets);

        if (newTarget != null)
        {
            currentTarget = newTarget;
        }
    }
        public void EnemyDeath()
    {
        GameObject deathEffectClone = Instantiate(deathEffect, transform.position, Quaternion.identity);
        movementSpeed=0;
        Destroy(deathEffectClone, 0.8f);
        Destroy(gameObject, 1f);
        EnemiesManager.instance.EnemyDeathCount();
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