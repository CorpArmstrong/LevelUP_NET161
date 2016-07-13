using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour 
{
	Renderer objRenderer;

	// Use this for initialization
	void Start ()
	{
		DelegateHandler.buttonClickDelegate += ChangePosition;
		DelegateHandler.buttonClickDelegate += ChangeColor;
		objRenderer = GetComponent<Renderer> ();
	}

	void ChangePosition()
	{
		transform.position = new Vector2 (transform.position.x + 2f, transform.position.y);
	}

	void ChangeColor()
	{
		objRenderer.material.color = Color.yellow;
	}

	// Unsubscribing Delegate
	void OnDisable()
	{
		DelegateHandler.buttonClickDelegate -= ChangeColor;
		DelegateHandler.buttonClickDelegate -= ChangePosition;
	}

}