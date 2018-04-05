using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    [SerializeField] int lootValue;
    [SerializeField] GameObject particle50, particle100, particle200, particle250, particle500;

    private GameObject currentParticle;

    LootController lc;  // GameController holding the LootController script

	// Use this for initialization
	void Start () {
        lc = GameObject.Find("GameController").GetComponent<LootController>();
        currentParticle = particle500;
        CheckValue();
	}

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Moneybag")
        {
            Debug.Log("Collision");
            lc.AddLootPoints(lootValue);
            Instantiate(currentParticle, transform.position, Quaternion.identity);
        }
    }

    void CheckValue()
    {
        Debug.Log("Start");
        if(lootValue <= 50 || lootValue >= 51 && lootValue <= 75)
        {
            lootValue = 50;
            currentParticle = particle50;
        }
        else if (lootValue >= 75 && lootValue <= 100 || lootValue >= 101 && lootValue <= 150)
        {
            lootValue = 100;
            currentParticle = particle100;
        }
        else if (lootValue >= 151 && lootValue <= 200 || lootValue >= 201 && lootValue <= 225)
        {
            lootValue = 200;
            currentParticle = particle200;
        }
        else if (lootValue >= 226 && lootValue <= 250 || lootValue >= 251 && lootValue <= 375)
        {
            lootValue = 250;
            currentParticle = particle250;
        }
        else if (lootValue >= 376 && lootValue <= 500 || lootValue >= 501)
        {
            lootValue = 500;
            currentParticle = particle500;
        }
        Debug.Log("Stop");
    }
}
