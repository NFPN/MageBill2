using UnityEngine;
using System.Collections;

public class BossTurrets : MonoBehaviour
{
    public float currentTimeFire;
    public float rateFireChange;
    public Transform BulletTrailPrefab;
    public Transform firePoint;
    public GameObject mageBill;
    public int rotationOffset;
    public Vector3 difference;
    public PausedTime doc;

    private bool startedPattern1;
    private bool startedPattern2;
    private bool startedPattern3;

    private void Start()
    {
        startedPattern1 = false;
        startedPattern2 = false;
        startedPattern3 = false;
        mageBill = GameObject.Find("MageBill");
        doc = GameObject.Find("_Manager").GetComponent<PausedTime>();
    }

    void Update()
    {
        currentTimeFire += Time.deltaTime;
        rateFireChange = Random.Range(4.0f, 8.0f);

        if (Boss1.sBoss1Life < 500 && startedPattern3)
        {
            startedPattern3 = true;
            rateFireChange = 1;
        }
        else if (Boss1.sBoss1Life < 2000 && !startedPattern2)
        {
            startedPattern2 = true;
            rateFireChange = 2;
        }
        else if (Boss1.sBoss1Life <= 5000 && !startedPattern1)
        {
            startedPattern1 = true;
            rateFireChange = 3;
            doc.tp.fillAmount += 0.2f;
        }


        if (currentTimeFire >= rateFireChange && mageBill != null)
        {
            Vector3 difference = mageBill.transform.position - transform.position;
            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
            Shoot();
            currentTimeFire = 0;
        }
    }

    public void Shoot()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
    }
}
