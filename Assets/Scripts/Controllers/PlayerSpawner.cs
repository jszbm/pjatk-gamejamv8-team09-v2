using Assets.Scripts.Player;
using TMPro;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawningArea;
    [SerializeField] private GameObject player;
    [SerializeField] private int scoreIncrement = 100;
    [SerializeField] private TextMeshProUGUI ScoreText;

    private Transform[] spawnPoints;
    private Transform spawnParent;
    private float childScale;
    private const string score = "Score:\n";
    private int scoreCounter = 0;

    void Start()
    {
        spawnPoints = spawningArea.GetComponentsInChildren<Transform>();
        if (spawnPoints.Length != 3)
        {
            Debug.LogError("Spawning area must have at least two child points to define spawn range.");
        }
        spawnParent = spawnPoints[0];
        childScale = spawnPoints[0].localScale.x;

        SignalBus.Instance.OnPlayerNeedToRespawn.AddListener(PlayerRespawn);
    }

    private void PlayerRespawn()
    {
        var spawnPosition = new Vector3(Random.Range(
            spawnParent.position.x + spawnPoints[1].localPosition.x * childScale, 
            spawnParent.position.x + spawnPoints[2].localPosition.x * childScale), 
            spawnParent.position.y, 
            spawnParent.position.z);

        player.transform.position = spawnPosition;
        player.SetActive(true);
        PlayerObject.Instance.StartInvisibility();

        scoreCounter += scoreIncrement;
        ScoreText.text = score + scoreCounter.ToString();

        SignalBus.Instance.OnPlayerRespawned.Invoke();
    }

    private void OnDestroy()
    {
        if (SignalBus.Instance != null)
        {
            SignalBus.Instance.OnPlayerNeedToRespawn.RemoveListener(PlayerRespawn);
        }
    }
}
