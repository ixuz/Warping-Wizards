using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseImageByDifficulty : MonoBehaviour {

  public Sprite easy;
  public Sprite medium;
  public Sprite hard;
  public Image destinationImage; 

  // Use this for initialization
  void Start () {
    if (State.instance.difficultyLevel == 0) {
      destinationImage.sprite = easy;
    }
    if (State.instance.difficultyLevel == 1) {
      destinationImage.sprite = medium;
    }
    if (State.instance.difficultyLevel == 2) {
      destinationImage.sprite = hard;
    }
  }
}
