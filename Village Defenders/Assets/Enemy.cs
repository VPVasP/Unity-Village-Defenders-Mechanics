using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float moveSpeed;
    private string wallTag = "Wall";
    [SerializeField] private List<Transform> walls = new List<Transform>();
    private int nextAttackTime = 5;
    private Animator anim;
    [SerializeField]  private Transform closestTarget;
    [SerializeField] private float distance;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim=GetComponentInChildren<Animator>();
        FindWalls();
    }
    private void Update()
    {
        Movement();
        closestTarget = GetClosestTarget(walls);
        distance= Vector3.Distance(this.transform.position, closestTarget.transform.position);
        print(distance);
        if (distance < 20)
        {
            anim.SetBool("isAttacking", true);
        }
        
    }
    private void FindWalls()
    {
        GameObject[] wallObjects = GameObject.FindGameObjectsWithTag(wallTag);

        
        foreach (GameObject wallObject in wallObjects)
        {
            Transform wallTransform = wallObject.transform;
            walls.Add(wallTransform);
        }
    }
    private void Movement()
    {
        closestTarget = GetClosestTarget(walls);
        agent.SetDestination(closestTarget.transform.position);
        anim.SetBool("isRunning", true);
        transform.LookAt(closestTarget);
    }
    private void Attack(Transform target)
    {
        
        
            if (Time.time >= nextAttackTime && closestTarget != null)
            {

            }
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
}
