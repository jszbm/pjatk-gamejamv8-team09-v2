using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    private Vector3 startPos;
    private bool goingForward = true;
    public float targetZ = -420f;
    
    private float speed = 22f;
    
    
    void Start()
    {
        startPos = transform.position;
    }
    
    void Update()
    {
        if (goingForward)
        {
            transform.position -= Vector3.forward * speed * Time.deltaTime;
            
            if (transform.position.z <= targetZ)
            {
                goingForward = false;
            }
        }
        else
        {

            transform.position = startPos;
            goingForward = true;
        }
    }
}
