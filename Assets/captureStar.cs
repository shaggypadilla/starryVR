using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class captureStar : MonoBehaviour {
	public int count = 0;
	public Color32 brightOrange = new Color32 (240, 127, 23, 1);
	public Color32 defaultOrange = new Color32 (129,62,0,1);

//	public GameObject myCursor = GameObject.Find("Cursor");
	public bool isHitStar;

	void Start(){
		isHitStar = false;
		Debug.Log ("START CAPTURE");
	}

	void MatSwap(Color32 newColor, GameObject anObject){

		anObject.GetComponent<MeshRenderer> ().materials[0].color = newColor;
//		GameObject.CreatePrim
	}


	void OnTriggerExit(Collider hit){
		GameObject myCursor = GameObject.Find("Cursor");
		MatSwap (defaultOrange, myCursor);
	}




	void OnTriggerEnter(Collider hit){

//		Text test = GameObject.Find("debug").GetComponent<Text>();
//		Text feedback = GameObject.Find("feedback").GetComponent<Text>();



		if (hit.tag == "star") {
			GameObject hitLight = hit.transform.GetChild (0).gameObject;

			//the user hit the star, change to brighten up the cursor
			GameObject myCursor = GameObject.Find("Cursor");
			MatSwap (brightOrange, myCursor);


			if(hitLight.light.range == 4){
//				Debug.Log ("hit star " + hit.name);
//				test.text = "Capture " + hit.name;




//				StartCoroutine("setOriginalText");

				//start the partciple system to keep looping
				hit.particleSystem.loop = true;
				hit.particleSystem.Play();

				isHitStar = true;
			}
			else{
//				feedback.text = feedback.text + "\n Missed";
		
			}


		}
	}

	void OnCollisionStay(Collision info){
		Debug.Log ("+OnCollisionStay");
		GameObject hit = info.gameObject;

		if (hit.tag == "star") {
			Debug.Log ("StayStar");
		}
	}
}
