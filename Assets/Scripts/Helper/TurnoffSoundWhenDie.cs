using UnityEngine;
using System.Collections;

public class TurnoffSoundWhenDie : MonoBehaviour {

	public AudioSource dir;

	
	// Update is called once per frame
	void Update () 
	{
		if (Time.timeScale == 0.25f)
			dir.Pause ();
	}
}
