using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlateformController : MonoBehaviour
{

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 nextPosition;

    public float speed;
    public Transform childTransform; 
    public Transform endTransform;

	// Use this for initialization
	void Start () {
        startPosition = childTransform.localPosition;
        endPosition = endTransform.localPosition;
        nextPosition = endPosition;
	}
	
	// Update is called once per frame
	void Update () {
        MovePlateform();
	}

    private void MovePlateform(){
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPosition, speed * Time.deltaTime);
        if(Vector3.Distance(childTransform.localPosition,nextPosition) <= 0.1){
            changeMovement();
        }
    }


    private void changeMovement(){
        nextPosition = nextPosition != startPosition ? startPosition : endPosition;
    }
}
