using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fsm : MonoBehaviour {

  Animator animator;
  RuntimeAnimatorController animationController;
  string currentState = null;

  List<string> stateNames = new List<string>();

  public static event FsmStateChangeEvent OnFsmStateChangeEvent;
  public delegate void FsmStateChangeEvent(GameObject go, Fsm fsm, string stateName);

  void Awake() {

    animator = GetComponent<Animator>();
  }

  public void AddStateName(string stateName) {
    stateNames.Add(stateName);
  }

  public string GetAnimatorStateName() {

    AnimatorStateInfo animatorStateInfo = animator.GetNextAnimatorStateInfo(0);

    foreach (string stateName in stateNames) {
      if (animatorStateInfo.IsName(stateName)) {
        return stateName;
      }
    }

    return null;
  }

  // Use this for initialization
  void Start () {

    currentState = GetAnimatorStateName();
  }
	
	// Update is called once per frame
	void Update () {

    string stateName = GetAnimatorStateName();
    if (stateName != null && stateName != currentState) {
      OnFsmStateChangeEvent(gameObject, this, stateName);
      currentState = stateName;
    }
	}
}
