using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour 
{
	public Image visualHealth;
	public float currentValue;
	public float maxHealth;
	public float currentHealth;
	private float CurrentHealth
	{
		get{return currentHealth;}
		set
		{
			currentHealth = value;
			HandleHealth();
		}
	}

	void Start()
	{
		maxHealth = gameObject.GetComponent<Boss1>().boss1Life;
		visualHealth = GameObject.Find("BossHealthBar").GetComponent<Image>();
	}



	void Update () 
	{
		currentHealth = Boss1.sBoss1Life;
		HandleHealth ();
	}

	private void HandleHealth()
	{
		currentValue = MapValues (currentHealth, 0, maxHealth, 0, 1);
		visualHealth.fillAmount = Mathf.MoveTowards(visualHealth.fillAmount, currentValue, Time.deltaTime);
		visualHealth.fillAmount = currentValue;
		if(currentHealth > maxHealth/2)
		{
			visualHealth.color = new Color32((byte)MapValues(currentHealth, maxHealth/2, maxHealth,255,0),255,0,255);
		}
		else 
		{
			visualHealth.color = new Color32(255,(byte)MapValues(currentHealth, 0, maxHealth/2,0,255),0,255);
		}
	}

	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
	{
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}


}
