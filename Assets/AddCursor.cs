using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCursor : MonoBehaviour {

  public Sprite sprite;
  public Vector2 center;

	// Use this for initialization
	void Start () {
    Cursor.SetCursor(sprite.texture, center, CursorMode.Auto);

  }
  // Update is called once per frame
  void Update () {
		
	}
}
