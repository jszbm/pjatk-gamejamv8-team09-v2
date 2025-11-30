using UnityEngine;

public class MusicSource : MonoBehaviour {
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Engine");
        FindObjectOfType<AudioManager>().Play("Rain");
    }
}
