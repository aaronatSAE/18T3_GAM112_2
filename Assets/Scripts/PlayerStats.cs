using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class PlayerStats : MonoBehaviour {

    private GameObject[] carrots;
    private GameObject[] lifeHeart;
    private int totalCarrots;
    private float timer;
    private float seconds;
    private int minute = 0;
    public int life = 3;
    public int score = 0;
    public bool finish = false;
    public GameObject scoreBoard;
    public TextMeshProUGUI[] scoreTxt;
    public TextMeshProUGUI[] totalCarrotDisplay;
    public TextMeshProUGUI[] timeMinute;
    public TextMeshProUGUI[] timeSeconds;

    // Use this for initialization
    void Start ()
    {
        //scoreTxt = scoreTxt.GetComponent<TextMeshProUGUI>();
        lifeHeart = GameObject.FindGameObjectsWithTag("LifeBar").OrderBy(go => go.name).ToArray();

        carrots = GameObject.FindGameObjectsWithTag("CarrotPickup");

        foreach (GameObject obj in carrots)
        {
            ++totalCarrots;
        }


    }

    // Update is called once per frame
    void Update()
    {
        

        timer += Time.deltaTime;
        seconds += Time.deltaTime;

        scoreTxt[0].text = score.ToString();
        totalCarrotDisplay[0].text = "     / " + totalCarrots.ToString();
        timeSeconds[0].text = seconds.ToString("F2");
        timeMinute[0].text = (minute).ToString("00") + ":";

        if (finish)
        {
            finish = false;
            LoadStats();
        }
        if(seconds >= 60f)
        {
            seconds = 0.0f;
            ++minute;
        }


        // player lives, heart symbols top left hand corner
        switch (life)
        {
            case 0:
                // player defeated ... do whatever, undecided
                lifeHeart[2].SetActive(false);
                lifeHeart[1].SetActive(false);
                lifeHeart[0].SetActive(false);
                break;
            case 1:
                lifeHeart[2].SetActive(false);
                lifeHeart[1].SetActive(false);
                lifeHeart[0].SetActive(true);
                break;
            case 2:
                lifeHeart[2].SetActive(false);
                lifeHeart[1].SetActive(true);
                lifeHeart[0].SetActive(true);
                break;
            case 3:
                lifeHeart[2].SetActive(true);
                lifeHeart[1].SetActive(true);
                lifeHeart[0].SetActive(true);
                break;
        }
	}

    private void LoadStats()
    {
        scoreBoard.SetActive(true);
        scoreTxt[1].text = scoreTxt[0].text;
        totalCarrotDisplay[1].text = totalCarrotDisplay[0].text;
        timeMinute[1].text = timeMinute[0].text;
        timeSeconds[1].text = timeSeconds[0].text;

    }
}
