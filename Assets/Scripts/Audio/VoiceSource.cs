using UnityEngine;

public class VoiceSource : MonoBehaviour
{
    public AudioSource source;
    private float playInterval = 15f;
    private float timer = 0f;
    
    [SerializeField]
    public AudioClip womenSpeak1;
    [SerializeField]
    public AudioClip womenSpeak2;
    [SerializeField]
    public AudioClip womenSpeak3;
    [SerializeField]
    public AudioClip womenSpeak4;
    [SerializeField]
    public AudioClip womenSpeak5;
    [SerializeField]
    public AudioClip womenSpeak6;

    void Update() {
        timer += Time.deltaTime;

        if (timer >= playInterval) {
            int rand =  Random.Range(1, 7);
                if (rand == 1) {
                    source.clip = womenSpeak1;
                    source.Play();
                    timer = 0f;
                    rand = Random.Range(1, 7);
                }
                else if (rand == 2) {
                    source.clip = womenSpeak2;
                    source.Play();
                    timer = 0f;
                    rand = Random.Range(1, 7);

                }
                else if (rand == 3) {
                    source.clip = womenSpeak3;
                    source.Play();
                    timer = 0f;
                    rand = Random.Range(1, 7);
                }
                else if (rand == 4) {
                    source.clip = womenSpeak4;
                    source.Play();
                    timer = 0f;
                    rand = Random.Range(1, 7);
                }
                else if (rand == 5) {
                    source.clip = womenSpeak5;
                    source.Play();
                    timer = 0f;
                    rand = Random.Range(1, 7);
                }
                else if (rand == 6) {
                    source.clip = womenSpeak6;
                    source.Play();
                    timer = 0f;
                    rand = Random.Range(1, 7);
                }
        }
    }
}
