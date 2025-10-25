using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    public TextMeshProUGUI statusTitle;

    public MeshRenderer border;

    public float baseHealth = 500f;
    private GameObject[] towers;

    private void Start()
    {
        towers = GameObject.FindGameObjectsWithTag("Build");
    }

    private void Update()
    {
        if (baseHealth <= 0f)
        {
            foreach (GameObject tower in towers)
            {
                Destroy(tower);
            }

            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            border.enabled = false;

            StartCoroutine(Victor());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            baseHealth -= 15f;
        }
        else if (other.gameObject.CompareTag("ArcherArrow"))
        {
            baseHealth -= 10f;
        }
        else if (other.gameObject.CompareTag("CannonBullet"))
        {
            baseHealth -= 30f;
        }
    }

    IEnumerator Victor()
    {
        statusTitle.text = "Victory";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
