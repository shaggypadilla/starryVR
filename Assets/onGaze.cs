using UnityEngine;
using System.Collections;

public class onGaze : MonoBehaviour {
	public Color32 onCollideBlue = new Color32 (42,58,116,1);
	public Color32 defaultOrange = new Color32 (129,62,0,1);
	public float countdown;
	public bool startTimer;

	// Use this for initialization
	void Start () {
		countdown = 3;
		startTimer = false;
	
	}


	void OnTriggerExit(Collider hit){
		GameObject myCursor = GameObject.Find("Cursor");
		MatSwap (defaultOrange, myCursor);
		startTimer = false;
		countdown = 3;
	}

	void MatSwap(Color32 newColor, GameObject anObject){
		
		anObject.GetComponent<MeshRenderer> ().materials[0].color = newColor;
		//		GameObject.CreatePrim
	}

	void Update(){
		if (startTimer) {
			countdown -= Time.deltaTime;
			if(countdown <= 0){
				Debug.Log ("waited for 3 seconds");
			}
		}
	}


	void StartTime(){
		countdown -= Time.deltaTime;
		startTimer = true;
	}
	
	
	void OnTriggerEnter(Collider hit){
		
		//		Text test = GameObject.Find("debug").GetComponent<Text>();
		//		Text feedback = GameObject.Find("feedback").GetComponent<Text>();
		
		
		
		if (hit.tag == "button") {
//			GameObject hitLight = hit.transform.GetChild (0).gameObject;
			Debug.Log ("Hit Button: " + hit.name);
			
			//the user hit the star, change to brighten up the cursor
			GameObject myCursor = GameObject.Find("Cursor");
			MatSwap (onCollideBlue, myCursor);

			StartTime ();
		
			
		}
	}
}
