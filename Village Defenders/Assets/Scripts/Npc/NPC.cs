using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    private Animator anim;
    private Rigidbody rb;
    public float npcWalkSpeed = 5f;
    private Vector3 targetLocation;
    private string npcTag="NPC";
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        targetLocation = RentacleZone.instance.GetRandomPoint();
        gameObject.tag = npcTag;
        PopulationManager.instace.population += 1;
        PopulationManager.instace.UpdatePopulationUI();
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
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
}

