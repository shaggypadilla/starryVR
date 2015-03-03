using UnityEngine;
using System.Collections;

public class createConstellation : MonoBehaviour {
	private connections path;

//	public void animatePath(){
//		path.animateStartEnd ();
//	}

	public void createPath(int startIDX,int endIDX){

		//create a star path
		GameObject starPath = (GameObject)Instantiate(Resources.Load("scale"));
		starPath.transform.parent = gameObject.transform;

		path = starPath.GetComponent<connections> ();
		
		//set C1 to connections start
		path.SStart = transform.GetChild(startIDX).gameObject;
		
		//set next to connections end
		path.SEnd = transform.GetChild(endIDX).gameObject;

		//animate the connections
		path.animateStartEnd ();

//		Invoke("animatePath",2);

	}

	public IEnumerator run(){
		int waittime = 3;

		int children = transform.childCount;
		for (int i = 0; i < children-1; ++i) {
			yield return new WaitForSeconds(waittime);
			createPath (i,i+1);
			//			yield return new WaitForSeconds (1);
			
		}
		yield return new WaitForSeconds(waittime);
		createPath (children - 1, 0);
	}
	
	// Use this for initialization
	void Start () {

			StartCoroutine ("run");
			Debug.Log ("+createConstellation");


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
