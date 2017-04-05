using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruction : MonoBehaviour {

	Component[] parts; 
	
	public double hardness; //threshold for breaking an object, nagnitude of impulse vector must be >hardness to break object
	
	
	// Use this for initialization
	void Start () {
		parts = transform.GetComponentsInChildren(typeof(Transform), true);  
	}
	
	void OnCollisionEnter (Collision coll) {
		print(coll.impulse);
		if(coll.collider.gameObject.tag == "Weapon" && coll.impulse.magnitude > hardness){
			//print(coll.name);
			GetComponent<Collider>().enabled = false; 
			foreach(Transform t in parts){
				t.gameObject.SetActive(true);
				t.SetParent(null);
				t.gameObject.AddComponent<Rigidbody>();
				t.gameObject.GetComponent<Rigidbody>().AddForce(coll.impulse);
                t.gameObject.AddComponent<timedestruction>();
			}
		transform.DetachChildren(); 
		Destroy(gameObject); 
		}
	}
}
