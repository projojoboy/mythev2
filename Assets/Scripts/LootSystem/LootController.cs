using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LootController : MonoBehaviour {

    private int amountLootCurrentRun = 0;
    private int highscore;
    [SerializeField] private Text amountMoneyText;

	// Use this for initialization
	void Start () {
        highscore = PlayerPrefs.GetInt("Highscore");
	}

    private void Update()
    {
        amountMoneyText.text = "€" + amountLootCurrentRun;
    }

    public void AddLootPoints(int amountLootToAdd)
    { 
        amountLootCurrentRun += amountLootToAdd;
    }
}
