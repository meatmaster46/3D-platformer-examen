using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public Text targetsLeft;

    public float timeLeft;
    public Text timeText;

    public GameObject winMenu;
    public GameObject loseMenu;

    private void Update()
    {
        if (targets.Count == 0)
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 0)
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        timeText.text = Mathf.RoundToInt(timeLeft).ToString();
        targetsLeft.text = targets.Count.ToString();
    }
}