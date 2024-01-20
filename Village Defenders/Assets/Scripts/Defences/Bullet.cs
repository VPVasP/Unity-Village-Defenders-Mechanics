using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyMovement>().EnemyDeath();
            Debug.Log("Collided" + collision.gameObject.name);
            Destroy(gameObject, 0.5f);
        }

    }
}
