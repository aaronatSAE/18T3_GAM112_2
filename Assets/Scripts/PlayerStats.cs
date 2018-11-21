using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class PlayerStats : MonoBehaviour {

    private GameObject[] lifeHeart;
    public int life = 3;
    public float score = 0f;
    public TextMeshProUGUI scoreTxt;

	// Use this for initialization
	void Start ()
    {
        scoreTxt = scoreTxt.GetComponent<TextMeshProUGUI>();
        lifeHeart = GameObject.FindGameObjectsWithTag("LifeBar").OrderBy(go => go.name).ToArray();
        
		
	}

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreTxt.text = score.ToString("F0");
    
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
}
