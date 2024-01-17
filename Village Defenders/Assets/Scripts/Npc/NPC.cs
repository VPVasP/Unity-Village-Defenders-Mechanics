using UnityEngine;

public class NPC : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public float npcWalkSpeed = 5f;
    private Vector3 targetLocation;
    private string npcTag = "NPC";
    private Canvas canvas;
    private Transform mainCamera;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        targetLocation = RentacleZone.instance.GetRandomPoint();
        gameObject.tag = npcTag;
        PopulationManager.instace.population += 1;
        PopulationManager.instace.UpdatePopulationUI();
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        MoveTowardsTarget();
    }

   private void MoveTowardsTarget()
    {
        if (transform.position != targetLocation)
        {
            var step = npcWalkSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);
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
}

