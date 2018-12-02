using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaState : MonoBehaviour {

  public int souls = 0;

  public static ArenaState instance;

  // Use this for initialization
  void Awake() {
		
    if (instance == null) {
      instance = this;
    } else {
      Destroy(gameObject);
      return;
    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
