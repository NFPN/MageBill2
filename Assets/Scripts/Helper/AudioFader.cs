using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioFader : MonoBehaviour 
{

	public AudioSource audio1;
	public AudioSource audio2;
    public float fadeInSpeed = 0.005f;
    public float fadeOutSpeed = 0.008f;
    public float maxVolume;
    private bool audio2Playing;

	void Start()
	{
        if (audio1 == null)
            audio1 = GameObject.Find("BGMusic").GetComponent<AudioSource>();
	}

    void Update()
    {
        if (audio1 != null)
        {
            fadeOut();
        }
        if (audio2 != null)
        {
            if (audio1 != null && audio1.volume <= 0.01f && audio2Playing == false)
            {
                audio1.Stop();
                audio2Playing = true;
                audio2.Play();
            }
            fadeIn();
        }
        
    }
	
	void fadeIn() 
	{
		if (audio2.volume < maxVolume) 
		{
			audio2.volume += fadeInSpeed * Time.deltaTime;
		}
	}
	
	void fadeOut() 
	{
		if(audio1.volume > 0.01f)
		{
            audio1.volume -= fadeOutSpeed;// * Time.deltaTime;
		}
	}
}
