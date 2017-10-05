using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHide : MonoBehaviour {

    public float BlinkTime = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(BlinkShow(2.2f));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        StartCoroutine(BlinksHide(BlinkTime));
    }


	IEnumerator BlinkShow(float blinkTime)
	{
        
		yield return new WaitForSeconds(blinkTime);
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		gameObject.GetComponent<PolygonCollider2D>().enabled = true;

	}

	IEnumerator BlinksHide(float blinkTime)
	{
		yield return new WaitForSeconds(blinkTime);
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;

	}
}
