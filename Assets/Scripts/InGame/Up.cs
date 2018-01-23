using UnityEngine;

public class Up : MonoBehaviour
{
    public GameObject isTheBoss;
    void Update ()
    {
        Vector3 dir = new Vector3(0, 1);
        isTheBoss.transform.Translate(dir * Time.deltaTime);
    }
}