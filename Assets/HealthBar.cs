using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

  public Wizard player;
  public RectTransform bar;
  private float maxHealthWidth = 100;

  // Use this for initialization
  void Start () {
    maxHealthWidth = bar.rect.width;
  }
	
	// Update is called once per frame
	void Update () {
    float percent = (float)player.hp / (float)player.maxHp;
    bar.sizeDelta = new Vector2(maxHealthWidth * percent, 16);
  }
}
