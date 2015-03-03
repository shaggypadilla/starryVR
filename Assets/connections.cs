using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class connections : MonoBehaviour {

	public GameObject SStart, SEnd;
	public string originalText = "Starry VR\n";



	// Use this for initialization
	void Start () {
		Vector3 startPos = SStart.transform.position;
		Vector3 endPos = SEnd.transform.position;

		//set the path start to the initial sphere
		transform.position = startPos;

		//rotate the path
		transform.rotation = Quaternion.FromToRotation (Vector3.up, endPos - startPos);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float calcDistance(float x1, float x2, float y1, float y2){
		float value = Mathf.Pow ((x1-y1),2) + Mathf.Pow ((x2-y2),2);
		float distance = Mathf.Sqrt(value);

//		Debug.Log ("X2: " + x2 + "X1: " + x1);
//		Debug.Log ("Y2: " + y2 + "Y1: " + y1);
//		Debug.Log ("Distance " + distance);
		return distance;
	}

	public IEnumerator setOriginalText(){
		yield return new WaitForSeconds(1);
		Text feedback = GameObject.Find("feedback").GetComponent<Text>();
		feedback.text = originalText;
	}

	public IEnumerator dropHalo(){
		yield return new WaitForSeconds(1);
		GameObject HaloLight = SEnd.transform.GetChild (0).gameObject;
		HaloLight.light.range = 0;

		captureStar hiddenCylinder = GameObject.Find("hiddenCylinder").GetComponent<captureStar>();
		Text feedback = GameObject.Find ("feedback").GetComponent<Text> ();
		if (!hiddenCylinder.isHitStar) {

			feedback.text = feedback.text + "Missed!";
			SEnd.gameObject.GetComponent<MeshRenderer> ().materials[0].color = new Color32(60, 60, 60 , 1); 
		} else {
			feedback.text = feedback.text + "Captured!";

		}

		StartCoroutine("setOriginalText");
		hiddenCylinder.isHitStar = false;
	}


	public IEnumerator lightHalo(){
		yield return new WaitForSeconds(1);
		GameObject HaloLight = SEnd.transform.GetChild (0).gameObject;
		HaloLight.light.range = 4;


		StartCoroutine ("dropHalo");

	}

	public void animateStartEnd(){
		Debug.Log ("+animateStartEnd");

		Vector3 startPos = SStart.transform.localPosition;
		Vector3 endPos = SEnd.transform.localPosition;


//		float distance = Vector3.Distance (startPos,endPos);
		float distance = calcDistance(startPos.y, startPos.x, endPos.y, endPos.x);

//		Debug.Log ("Rotation angle?" + transform.rotation);

		LeanTween.scaleY (gameObject, distance, 1f);


//		Debug.Log ("HaloLight " + HaloLight.name);
		Debug.Log ("-animation");
		StartCoroutine ("lightHalo");


//		LeanTween.scaleY (gameObject, 3.1f, 1f);
//		LeanTween.scaleY (gameObject, 0f, 1f).setDelay (2f);



		//transform.localScale = new Vector3 (transform.localScale.x, 3.1f, transform.localScale.z);
	}


}
