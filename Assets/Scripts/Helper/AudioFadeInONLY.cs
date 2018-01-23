using UnityEngine;

public class AudioFadeInONLY : MonoBehaviour
{
    public AudioSource audioS;
    public float fadeInSpeed = 0.005f;
    public float maxVolume;    
    	
	void Update ()
    {
        if (audioS.volume < maxVolume)
        {
            audioS.volume += fadeInSpeed * Time.deltaTime;
        }
    }
}
