using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private GameObject nearBuild;
    private float nearDistance = Mathf.Infinity;

    public Image healthBar;

    public GameObject bulletPrefab;
    public Transform bulletPoint;
    public float delay = 1f;
    private float countdown = 0f;
    private bool canFire = false;

    public float soldierMaxHealth = 100f;
    private float soldierHealth;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        soldierHealth = soldierMaxHealth;
    }

    private void Update()
    {
        if (soldierHealth <= 0)
        {
            agent.isStopped = true;
            nearBuild = null;
            Destroy(gameObject);
        }

        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            canFire = true;
            countdown = delay;
        }

        Collider[] buildings = Physics.OverlapSphere(transform.position, 50f);

        foreach (Collider building in buildings)
        {
            if (building.CompareTag("Build") || building.CompareTag("Base"))
            {
                float distance = Vector3.Distance(transform.position, building.transform.position);
                if (distance < nearDistance)
                {
                    nearDistance = distance;
                    nearBuild = building.gameObject;
                }
            }
        }

        if (nearBuild != null && soldierHealth != 0)
        {
            agent.isStopped = false;

            healthBar.gameObject.SetActive(true);
            healthBar.fillAmount = soldierHealth / soldierMaxHealth;

            Vector3 targetDirection = nearBuild.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
            Vector3 rotation = lookRotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            float buildDistance = Vector3.Distance(transform.position, nearBuild.transform.position);

            if (buildDistance <= 16f)
            {
                animator.SetBool("isAttack", true);

                if (canFire)
                {
                    Fire();
                    canFire = false;
                }
            }
            else
            {
                animator.SetBool("isAttack", false);
            }

            agent.SetDestination(nearBuild.transform.position);
        }
        else if (nearBuild == null)
        {
            healthBar.gameObject.SetActive(false);
            nearDistance = Mathf.Infinity;
            agent.isStopped = true;
        }
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        bullet.GetComponent<CannonBullet>().target = nearBuild.transform;
        bullet.GetComponent<CannonBullet>().canMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            soldierHealth -= 25f;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            soldierHealth -= 50f;
            Destroy(other.gameObject);
        }
    }
}
