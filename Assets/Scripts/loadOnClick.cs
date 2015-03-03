using UnityEngine;
using System.Collections;

public class loadOnClick : MonoBehaviour {

	public void LoadScene(int level)
	{
		Application.LoadLevel (level); //level is an index in our build settings
	}
}
