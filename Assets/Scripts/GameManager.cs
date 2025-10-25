using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlacementSystem PlacementSystem;
    public TextMeshProUGUI stateTitle;

    private GameObject[] soldiers;

    private void Update()
    {
        soldiers = GameObject.FindGameObjectsWithTag("Soldier");

        if (soldiers.Count() == 0 && PlacementSystem.knightCount == 0 && PlacementSystem.archerCount == 0 && PlacementSystem.cannonCount == 0)
        {
            StartCoroutine(Defeat());
        }
    }

    IEnumerator Defeat()
    {
        stateTitle.text = "Defeat";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
