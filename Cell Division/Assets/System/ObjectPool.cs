using UnityEngine;
using System.Collections;

public class ObjectPool : MonoBehaviour {

	// Pool of game objects
	GameObject[] pool = null;

	// How many objects should be pooled
	public int poolAmount = 0;

	// Prefab to generate for the pool
	public GameObject poolPrefab;


	// Use this for initialization
	void Start() {
		pool = new GameObject[poolAmount];	

		// create the pooled objects
		for (int i = 0; i < poolAmount; i++) {
			GameObject newobj = Instantiate(poolPrefab) as GameObject;
			newobj.SetActiveRecursively(false);
			newobj.transform.parent = transform;
			pool[i] = newobj;
		}
	}


	GameObject Activate() {
		// find an inactive object
		for (int i = 0; i < poolAmount; i++) {
			if (!pool[i].active) {
				pool[i].SetActiveRecursively(true);
				return pool[i];
			}
		}

		return null;
	}
}
