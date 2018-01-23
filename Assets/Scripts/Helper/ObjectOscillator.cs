using UnityEngine;
using System.Collections;

public class ObjectOscillator : MonoBehaviour
{
    public GameObject bullet;

    public float speedMult = 1.0f;
    public float rangeMult = 1.0f;    
    public float shootInterval = 1.0f;
    public float baseX = 0;
    public float shootTimeAc = 0;

    public int intervalController;

	void Start ()
    {        
        baseX = transform.position.x;       
    }	
	
	void Update ()
    {
        Vector3 position = transform.position;
        float interval = Mathf.Sin(Time.time * (speedMult / rangeMult)) * rangeMult;
        bool shoot = false;

        if(shootTimeAc >= shootInterval)
        {
            shootTimeAc = 0;
            shoot = true;
        }
        else
            shootTimeAc += Time.deltaTime;

        position.x = baseX + interval;        
        transform.position = intervalController * position;

        if (shoot)
        {
            shootInterval = Random.Range(0.1f, 1.5f);
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
	}
}
