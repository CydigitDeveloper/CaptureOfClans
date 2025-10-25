using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : MonoBehaviour
{
    public Transform root;
    private GameObject nearSoldier;
    private float nearDistance = Mathf.Infinity;

    public GameObject arrowPrefab;
    public Transform arrowPoint;
    public float delay = 1f;
    public float range = 15f;
    private float countdown = 0f;
    private bool canFire = false;

    public float towerHealth = 100f;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        if (towerHealth <= 0f)
        {
            Destroy(gameObject);
        }

        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            canFire = true;
            countdown = delay;
        }

        Collider[] Soldiers = Physics.OverlapSphere(transform.position, range);

        foreach (Collider soldier in Soldiers)
        {
            if (soldier.CompareTag("Soldier"))
            {
                float distance = Vector3.Distance(transform.position, soldier.transform.position);
                if (distance < nearDistance)
                {
                    nearDistance = distance;
                    nearSoldier = soldier.gameObject;
                }
            }
        }

        if (nearSoldier != null && towerHealth != 0f)
        {
            Vector3 targetDirection = nearSoldier.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
            Vector3 rotation = lookRotation.eulerAngles;
            root.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (canFire)
            {
                Fire();
                canFire = false;
            }
        }
        else
        {
            nearDistance = Mathf.Infinity;
        }
    }

    public void Fire()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowPoint.position, arrowPoint.rotation);
        arrow.GetComponent<Arrow>().target = nearSoldier.transform;
        arrow.GetComponent<Arrow>().canMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            towerHealth -= 15f;
        }
        else if (other.gameObject.CompareTag("ArcherArrow"))
        {
            towerHealth -= 10f;
        }
        else if (other.gameObject.CompareTag("CannonBullet"))
        {
            towerHealth -= 30f;
        }
    }
}
