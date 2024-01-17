using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class DefenceTower : MonoBehaviour
{
    [SerializeField] private Transform firePosition;
    [SerializeField] private Transform canon;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform[] targets;
    private void Start()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Enemy");
        targets = new Transform[targetObjects.Length];

        for (int i = 0; i < targetObjects.Length; i++)
        {
            targets[i] = targetObjects[i].transform;
        }
        StartCoroutine(ShootTargetsDelay());
    }
    private void Update()
    {
        Transform closestTarget = GetClosestTarget(targets);

        if (closestTarget != null)
        {
            RotateCanonTowardsTarget(closestTarget.position);
        }
    }
    private IEnumerator ShootTargetsDelay()
    {
        while (true)
        {
            Transform closestTarget = GetClosestTarget(targets);
          
       

            if (closestTarget != null)
            {
                ShootTargets(closestTarget.position);
            }
            yield return new WaitForSeconds(2f);
        }
    }
    

    private void ShootTargets(Vector3 targetPosition)
    {
        GameObject bulletClone = Instantiate(bullet, firePosition.position, Quaternion.identity);
        bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward *50);
        Destroy(bulletClone,5f);
    }
    private void RotateCanonTowardsTarget(Vector3 targetPosition)
    {
        Vector3 targetDirection = targetPosition - canon.position;

        float targetRotationZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        targetRotationZ = Mathf.Clamp(targetRotationZ, -40,40);

        canon.rotation = Quaternion.Euler(0f, 0f, targetRotationZ);
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
}
