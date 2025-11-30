using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    private Vector3 startPos;
    private bool goingForward = true;
    public float targetZ = -420f;
    
    private float speed = 22f;
    
    void Start()
    {
        startPos = transform.localPosition;
    }
    
    void Update()
    {
        if (goingForward)
        {
            transform.localPosition -= new Vector3(0,0,1) * speed * Time.deltaTime;
            
            if (transform.localPosition.z <= targetZ)
            {
                goingForward = false;
            }
        }
        else
        {

            transform.localPosition = startPos;
            goingForward = true;
        }
    }
}
