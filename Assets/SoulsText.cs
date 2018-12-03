using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulsText : MonoBehaviour {

  public Text text;
  	
	// Update is called once per frame
	void Update () {

    if (ArenaState.instance.souls >= 50 + 25 * State.instance.difficultyLevel) {
      Destroy(gameObject);
      text.text = "The Gate is open!";
    } else {
      int moreSouls = (50 + 25 * State.instance.difficultyLevel) - ArenaState.instance.souls;
      text.text = "Collect " + moreSouls + " more souls to open the Gate!";
    }

  }
}
