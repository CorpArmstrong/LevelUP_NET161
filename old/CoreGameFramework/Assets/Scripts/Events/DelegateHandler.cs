using UnityEngine;
using System.Collections;

public class DelegateHandler : MonoBehaviour
{
	public delegate void OnButtonClickDelegate ();
	public static event OnButtonClickDelegate buttonClickDelegate;

	public void OnButtonClick()
	{
		buttonClickDelegate();
	}
}
