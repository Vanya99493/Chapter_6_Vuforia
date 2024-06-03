using UnityEngine;
using Vuforia;

namespace Assets.Scripts.Infra.PauseModule
{
    public class PauseController : MonoBehaviour
    {
        [SerializeField] private PlaneFinderBehaviour _planeFinder;

        public bool IsPaused { get; private set; }

        public PauseController(bool isPaused = false)
        {
            IsPaused = isPaused;
            SetActivePlaneFinder(true);
        }

        public void SwitchPause()
        {
            IsPaused =!IsPaused;
            SetActivePlaneFinder(!IsPaused);
        }

        public void ResetPause()
        {
            IsPaused = false;
            SetActivePlaneFinder(true);
        }

        private void SetActivePlaneFinder(bool isActive)
        {
            _planeFinder.gameObject.SetActive(isActive);
        }
    }
}