using UnityEngine;

public class EndOfWindow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            SignalBus.Instance.OnPlayerNeedToRespawn.Invoke();
        }

        if (other.transform.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
