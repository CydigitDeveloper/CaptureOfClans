using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherArrow : MonoBehaviour
{
    public Transform target;
    public bool canMove;
    public float arrowSpeed;

    private void Update()
    {
        if (canMove && target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, arrowSpeed);
        }

        if (target == null)
        {
            Destroy(gameObject);
        }
    }
}
