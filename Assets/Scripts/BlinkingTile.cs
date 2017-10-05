using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingTile : MonoBehaviour {

	private bool is_shown = true;
    public float ShownTime = 1.0f;
    public float HideTime = 1.0f;

	void Start()
	{
		InvokeRepeating("ToggleBlink", ShownTime, HideTime);
	}

	void ToggleBlink()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = !is_shown;
        gameObject.GetComponent<PolygonCollider2D>().enabled = !is_shown;
        is_shown = !is_shown;
	}
}
