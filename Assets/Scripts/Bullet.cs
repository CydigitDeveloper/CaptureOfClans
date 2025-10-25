using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public bool canMove;
    public float bulletSpeed;

    private void Update()
    {
        if (canMove && target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, bulletSpeed);
        }

        if (target == null)
        {
            Destroy(gameObject);
        }
    }
}
