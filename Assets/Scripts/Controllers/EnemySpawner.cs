using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawningArea;
        [SerializeField] private GameObject enemy;
        [SerializeField] private float spawnInterval = 2f;

        private Transform[] spawnPoints;
        private Transform spawnParent;
        private float childScale;

        void Start()
        {
            spawnPoints = spawningArea.GetComponentsInChildren<Transform>();
            if (spawnPoints.Length != 3)
            {
                Debug.LogError("Spawning area must have at least two child points to define spawn range.");
            }
            spawnParent = spawnPoints[0];
            childScale = spawnPoints[0].localScale.x;

            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                var spawnPosition = new Vector3(Random.Range(
                    spawnParent.position.x - spawnPoints[1].position.x * childScale, 
                    spawnParent.position.x + spawnPoints[2].position.x * childScale), 
                    spawnParent.position.y, 
                    spawnParent.position.z);
                Instantiate(enemy, spawnPosition, transform.rotation);

                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
