using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerObject : MonoBehaviour
    {
        public static PlayerObject Instance;
        //public bool IsInvisible { get; private set; } = false;

        [SerializeField] private float timeForInvisibility = 2f;
        public bool IsInvisible { get; private set; } = false;

        private void Awake()
        {
            Instance = this;
            StartInvisibility();
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }

            //if (SignalBus.Instance != null)
            //{
            //    SignalBus.Instance.OnInvisibility.RemoveListener(HandleInvisibility);
            //}
        }

        public void StartInvisibility()
        {
            StartCoroutine(Invisibility());
        }

        private IEnumerator Invisibility()
        {
            IsInvisible = true;
            Debug.Log("Invisibility started");
            yield return new WaitForSeconds(timeForInvisibility);
            IsInvisible = false;
            Debug.Log("Invisibility ended");
        }

        //private void Start()
        //{
        //    SignalBus.Instance.OnInvisibility.AddListener(HandleInvisibility);
        //}

        //private void HandleInvisibility()
        //{
        //    StartCoroutine(Invisibility());
        //}

        //private IEnumerator Invisibility()
        //{
        //    IsInvisible = true;
        //    yield return new WaitForSeconds(timeForInvisibility);
        //    IsInvisible = false;
        //}
    }
}
