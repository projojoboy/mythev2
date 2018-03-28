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
        CheckValue();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Moneybag")
        {
            Debug.Log("collision");
            lc.AddLootPoints(lootValue);
            Instantiate(currentParticle, transform.position, Quaternion.identity);
        }
    }

    void CheckValue()
    {
        
        if(lootValue <= 49 || lootValue >= 51 && lootValue <= 75)
        {
            lootValue = 50;
            currentParticle = particle50;
        }
        else if (lootValue >= 75 && lootValue <= 99 || lootValue >= 101 && lootValue <= 150)
        {
            lootValue = 100;
            currentParticle = particle100;
        }
        else if (lootValue >= 151 && lootValue <= 199 || lootValue >= 201 && lootValue <= 225)
        {
            lootValue = 200;
            currentParticle = particle200;
        }
        else if (lootValue >= 226 && lootValue <= 249 || lootValue >= 251 && lootValue <= 375)
        {
            lootValue = 250;
            currentParticle = particle250;
        }
        else if (lootValue >= 376 && lootValue <= 499 || lootValue >= 501)
        {
            lootValue = 500;
            currentParticle = particle500;
        }
    }
}
