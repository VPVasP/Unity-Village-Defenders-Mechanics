using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public float npcWalkSpeed = 5f;
    private Vector3 targetLocation;
    private string npcTag = "NPC";
    [SerializeField] private Canvas canvas;
    private Transform mainCamera;
    [SerializeField] private float npcRotateSpeed = 180;
    private LayerMask npcLayerMask;
    public NavMeshAgent navMeshAgent;
    public bool canWalkAround;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        canvas = GetComponentInChildren<Canvas>();
        targetLocation = RentacleZone.instance.GetRandomPoint();
        gameObject.tag = npcTag;
        PopulationManager.instace.population += 1;
        PopulationManager.instace.UpdatePopulationUI();
        mainCamera = Camera.main.transform;
        npcLayerMask = 1 << LayerMask.NameToLayer("NPC");

        npcRotateSpeed = 180f;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = 0.1f;
        canWalkAround = true;
    }

   void Update()
{
    if (canWalkAround)
    {
        MoveTowardsTarget();
    }
    else if(!canWalkAround)
    {
            npcWalkSpeed = 0;
            navMeshAgent.speed = 0;
            navMeshAgent.acceleration = 0;
            navMeshAgent.angularSpeed = 0;
        Debug.Log("stopped walking around");
    }

    CanvasFaceCamera();
}

    private void MoveTowardsTarget()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {

            targetLocation = RentacleZone.instance.GetRandomPoint();
            navMeshAgent.SetDestination(targetLocation);
        }


        Quaternion targetRotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, npcRotateSpeed * Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, npcRotateSpeed * Time.deltaTime);



    }

    private void CanvasFaceCamera()
    {
        canvas.transform.LookAt(canvas.transform.position + mainCamera.rotation * Vector3.forward,
                         mainCamera.rotation * Vector3.up);
    }
    public void PlayMoraleAnimation()
    {
        anim.SetTrigger("Cheer");
        npcWalkSpeed = 0;
        StartCoroutine(MoraleAnimationEnumerator());
    }
    IEnumerator MoraleAnimationEnumerator()
    {
        yield return new WaitForSeconds(2.5f);
        npcWalkSpeed = 2.5f;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
     
    }
}

