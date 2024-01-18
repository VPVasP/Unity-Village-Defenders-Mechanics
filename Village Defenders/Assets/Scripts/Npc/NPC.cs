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
    }

    void Update()
    {
        MoveTowardsTarget();
        CanvasFaceCamera();
    }

   private void MoveTowardsTarget()
    {
        if (transform.position != targetLocation)
        {
            Vector3 direction = (targetLocation - transform.position).normalized;
            var step = npcWalkSpeed * Time.deltaTime;
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
}

