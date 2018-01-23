using UnityEngine;

public class AudioScaler : MonoBehaviour 
{	
	public AudioSource audio1;

	void Update () 
	{
		audio1.pitch = Time.timeScale;
	}
}
