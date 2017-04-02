using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruction : MonoBehaviour {

	Component[] parts; 
	
	// Use this for initialization
	void Start () {
		parts = transform.GetComponentsInChildren(typeof(Transform), true);  
	}
	
	void OnCollisionEnter (Collision coll) {
		if(coll.collider.gameObject.tag == "Weapon"){
			//print(coll.name);
			GetComponent<Collider>().enabled = false; 
			foreach(Transform t in parts){
				t.gameObject.SetActive(true);
				t.SetParent(null);
				t.gameObject.AddComponent<Rigidbody>();
				t.gameObject.GetComponent<Rigidbody>().AddForce(coll.impulse); 
				print("new cube");
			}
		transform.DetachChildren(); 
		Destroy(gameObject); 
		}
	}
}
