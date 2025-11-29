using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Controllers
{
    public class PauseManager : MonoBehaviour
    {
        public static bool IsPaused { get; private set; }
        private void Start()
        {
            InputHandler.Instance.InputActions.Menu.Pause.performed += HandlePauseEvent;
        }

        private void HandlePauseEvent(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                IsPaused = !IsPaused;
                SignalBus.Instance.OnPauseStateChanged.Invoke(IsPaused);

                Time.timeScale = IsPaused ? 0f : 1f;
            }
        }
    }
}
