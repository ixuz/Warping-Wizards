using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    if (ArenaState.instance.souls >= 50 + 25 * State.instance.difficultyLevel) {
      Destroy(gameObject);
    }
	}
}
