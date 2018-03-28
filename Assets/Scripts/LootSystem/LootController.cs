using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour {

    private int amountLootCurrentRun = 0;
    private int highscore;

	// Use this for initialization
	void Start () {
        highscore = PlayerPrefs.GetInt("Highscore");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddLootPoints(int amountLootToAdd)
    { 
        amountLootCurrentRun += amountLootToAdd;
        Debug.Log(amountLootCurrentRun);
    }
}
