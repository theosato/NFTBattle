using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour {

	GameObject buttons;
	GameObject canvasMonster;

	[SerializeField]
	GameObject blink;
	
	public void TakeAShot()
	{
		StartCoroutine ("CaptureIt");
	}

	IEnumerator CaptureIt()
	{
 		canvasMonster = GameObject.Find("Moves");
 		buttons = GameObject.Find("Buttons");

		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		// Hide 
 		canvasMonster.transform.localScale = new Vector3(0, 0, 0);
 		buttons.transform.localScale = new Vector3(0, 0, 0);
		ScreenCapture.CaptureScreenshot(pathToSave);
		yield return new WaitForEndOfFrame();
		Instantiate (blink, new Vector2(0f, 0f), Quaternion.identity);
		// Show 
		canvasMonster.transform.localScale = new Vector3(1, 1, 1);
 		buttons.transform.localScale = new Vector3(1, 1, 1);
	}

}
