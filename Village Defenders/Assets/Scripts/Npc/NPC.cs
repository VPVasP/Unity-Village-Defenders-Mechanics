using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private LayerMask obstacleLayerMask;
    [SerializeField] private float obstacleDetectionDistance = 2f;
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
        obstacleLayerMask = 1 << LayerMask.NameToLayer("Obstacle");
        npcWalkSpeed = 2.5f;
        npcRotateSpeed = 180f;
        obstacleDetectionDistance = 4f;
    }

    void Update()
    {
        MoveTowardsTarget();
        CanvasFaceCamera();
        Debug.Log(obstacleDetectionDistance);
    }

    private void MoveTowardsTarget()
    {
        if (transform.position != targetLocation)
        {
            Vector3 direction = (targetLocation - transform.position).normalized;
            var step = npcWalkSpeed * Time.deltaTime;

            RaycastHit hit;

           
            if (Physics.Raycast(transform.position, direction, out hit, obstacleDetectionDistance, obstacleLayerMask))
            {
                
                targetLocation = Vector3.Lerp(targetLocation, hit.point + hit.normal * obstacleDetectionDistance, 0.5f);
                direction = (targetLocation - transform.position).normalized;
             
            }

            transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, npcRotateSpeed * Time.deltaTime);
        }
        else
        {
            targetLocation = RentacleZone.instance.GetRandomPoint();
        }
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
        Gizmos.DrawWireSphere(transform.position, obstacleDetectionDistance);
    }
}

