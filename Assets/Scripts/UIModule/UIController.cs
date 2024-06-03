using System;
using UIModule.Panels.ChangeIndexPanelModule;
using UIModule.Panels.PausePanelModule;
using UnityEngine;

namespace UIModule
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private PausePanel _pausePanel;
        [SerializeField] private ChangeIndexPanel _changeIndexPanel;

        public void Initialize(Action OnPauseButtonClick, Action OnIncreaseButtonClick, Action OnDecreaseButtonClick)
        {
            _pausePanel.Initialize(OnPauseButtonClick);
            _changeIndexPanel.Initialize(OnIncreaseButtonClick, OnDecreaseButtonClick);
        }
        
        public void ActivateUI()
        {
            gameObject.SetActive(true);
        }

        public void DeactivateUI()
        {
            gameObject.SetActive(false);
        }

        public void SetPause(bool isPaused)
        {
            _changeIndexPanel.SetInteractable(!isPaused);
        }
    }
}