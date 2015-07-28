using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinState : MonoBehaviour {

	public Text youWinText;
	private bool foundHome = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		Debug.Log("triggered!");
		if (!foundHome)
		{
			foundHome = true;
			youWinText.enabled = true;
		}
		else
		{

		}
	}
}
