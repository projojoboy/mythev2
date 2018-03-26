using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    [SerializeField] int lootValue;

    [SerializeField] GameObject particle;

    LootController lc;  // GameController holding the LootController script

	// Use this for initialization
	void Start () {
        lc = GameObject.Find("GameController").GetComponent<LootController>();
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
            Instantiate(particle);
        }
    }
}
