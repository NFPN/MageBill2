using UnityEngine;

public class RotatorTime : MonoBehaviour
{

    public float aRot;
    public float speed;

    void Update()
    {
        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }

        speed = 7;
        aRot = speed * Time.deltaTime;
        transform.Rotate(new Vector3(0.0f, 0.0f, aRot));
        if (aRot >= 360)
            aRot = 0;
    }
}