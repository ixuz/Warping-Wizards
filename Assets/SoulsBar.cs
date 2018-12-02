using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsBar : MonoBehaviour {

  public ArenaState arenaState;
  public RectTransform bar;
  private float maxHealthWidth = 100;

  // Use this for initialization
  void Start () {
    maxHealthWidth = bar.rect.width;
  }
	
	// Update is called once per frame
	void Update () {
    int targetSouls = 50 + 25 * State.instance.difficultyLevel;
    float percent = (float)arenaState.souls / (float)targetSouls;
    bar.sizeDelta = new Vector2(maxHealthWidth * percent, 16);
  }
}
