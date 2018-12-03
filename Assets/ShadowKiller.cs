using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

  }

  public virtual void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "Player") {
      other.gameObject.GetComponent<Wizard>().killShadow();
      Destroy(gameObject);
    }
  }
}
