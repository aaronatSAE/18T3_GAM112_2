using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    private GameObject[] lifeHeart;
    public int life = 3;
    public int score;
    public TextMeshProUGUI scoreTxt;

	// Use this for initialization
	void Start ()
    {
        scoreTxt = scoreTxt.GetComponent<TextMeshProUGUI>();
        lifeHeart = GameObject.FindGameObjectsWithTag("LifeBar");
		
	}

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();

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
                lifeHeart[2].SetActive(true);
                lifeHeart[1].SetActive(false);
                lifeHeart[0].SetActive(false);
                break;
            case 2:
                lifeHeart[2].SetActive(true);
                lifeHeart[1].SetActive(true);
                lifeHeart[0].SetActive(false);
                break;
            case 3:
                lifeHeart[2].SetActive(true);
                lifeHeart[1].SetActive(true);
                lifeHeart[0].SetActive(true);
                break;
        }
	}
}
