using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

  public static State instance;

  public int difficultyLevel = 1; // 1, 2 or 3

  void Awake() {

    if (instance == null) {
      instance = this;
    } else {
      Destroy(gameObject);
      return;
    }

    DontDestroyOnLoad(gameObject);
  }

  public void SetDifficultyLevel(int difficultyLevel) {
    this.difficultyLevel = difficultyLevel;
  }
}
