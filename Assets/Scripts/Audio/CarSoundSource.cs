using UnityEngine;

public class CarSoundSource : MonoBehaviour
{
    public AudioSource source;
    private float playInterval = 10f;
    private float timer = 0f;
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= playInterval)
        {
            source.Play();
            timer = 0f;
        }
    }
}
