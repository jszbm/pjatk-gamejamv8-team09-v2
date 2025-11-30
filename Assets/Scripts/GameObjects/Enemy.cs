using Assets.Scripts.Player;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float base_y_speed = 3;

    private void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0, -base_y_speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            SignalBus.Instance.OnGameOver.Invoke();
            SignalBus.Instance.OnPauseStateChanged.Invoke(true);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player")/* && !PlayerObject.Instance.IsInvisible*/)
    //    {
    //        Debug.Log("Enemy collided with Player. Game Over!");
    //        SignalBus.Instance.OnGameOver.Invoke();
    //    }
    //    //else if (collision.gameObject.CompareTag("Player") && PlayerObject.Instance.IsInvisible)
    //    //{
    //    //    Debug.Log("Enemy collided with Invisible Player. Enemy destroyed!");
    //    //    SignalBus.Instance.OnPlayerAteEnemy.Invoke();

    //    //    Destroy(gameObject);
    //    //}
    //}
}
