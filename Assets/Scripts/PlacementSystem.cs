using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public GameObject[] gizmoObjects;
    public float knightCount = 20f;
    public float archerCount = 10f;
    public float cannonCount = 3f;
    public TextMeshProUGUI knightCountText;
    public TextMeshProUGUI archerCountText;
    public TextMeshProUGUI cannonCountText;
    private GameObject spawnObject;
    private GameObject selectObject;
    private Vector3 objectPosition;
    private RaycastHit hit;
    private bool isDrag;
    private int soldierIndex;

    private void Start()
    {
        knightCountText.text = knightCount.ToString();
        archerCountText.text = archerCount.ToString();
        cannonCountText.text = cannonCount.ToString();
    }

    private void Update()
    {
        if (spawnObject != null)
        {
            spawnObject.transform.position = objectPosition;

            if (Input.GetMouseButtonDown(1) && isDrag && soldierIndex == 0 && knightCount > 0)
            {
                PlaceObject();
            }
            else if (Input.GetMouseButtonDown(1) && isDrag && soldierIndex == 1 && archerCount > 0)
            {
                PlaceObject();
            }
            else if (Input.GetMouseButtonDown(1) && isDrag && soldierIndex == 2 && cannonCount > 0)
            {
                PlaceObject();
            }
        }

        if (selectObject != null)
        {
            selectObject.transform.position = objectPosition;
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.transform.tag == "Ground")
            {
                objectPosition = hit.point;
            }
        }
    }

    public void SelectObject(int index)
    {
        soldierIndex = index;

        if (soldierIndex == 0 && knightCount > 0)
        {
            spawnObject = spawnObjects[soldierIndex];
            selectObject = gizmoObjects[soldierIndex];

            foreach (GameObject gizmos in gizmoObjects)
            {
                gizmos.SetActive(false);
            }
            gizmoObjects[soldierIndex].SetActive(true);
            isDrag = true;
        }
        else if (soldierIndex == 1 && archerCount > 0)
        {
            spawnObject = spawnObjects[soldierIndex];
            selectObject = gizmoObjects[soldierIndex];

            foreach (GameObject gizmos in gizmoObjects)
            {
                gizmos.SetActive(false);
            }
            gizmoObjects[soldierIndex].SetActive(true);
            isDrag = true;
        }
        else if (soldierIndex == 2 && cannonCount > 0)
        {
            spawnObject = spawnObjects[soldierIndex];
            selectObject = gizmoObjects[soldierIndex];

            foreach (GameObject gizmos in gizmoObjects)
            {
                gizmos.SetActive(false);
            }
            gizmoObjects[soldierIndex].SetActive(true);
            isDrag = true;
        }
    }

    public void PlaceObject()
    {
        if (soldierIndex == 0)
        {
            knightCount--;
            knightCountText.text = knightCount.ToString();
        }
        else if (soldierIndex == 1)
        {
            archerCount--;
            archerCountText.text = archerCount.ToString();
        }
        else if (soldierIndex == 2)
        {
            cannonCount--;
            cannonCountText.text = cannonCount.ToString();
        }

        Instantiate(spawnObject, objectPosition, transform.rotation);
    }
}
