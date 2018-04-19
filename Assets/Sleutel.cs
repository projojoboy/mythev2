using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sleutel : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Sleutelgat") {
			Debug.Log ("hoi");
			SceneManager.LoadScene ("winscene");
		}
	
	}


}
