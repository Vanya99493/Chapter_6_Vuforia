using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.Panels.PausePanelModule
{
    public class PausePanel : BasePanel
    {
        [SerializeField] private Button _pauseButton;

        public void Initialize(Action OnPauseButtonClick)
        {
            _pauseButton.onClick.AddListener(() => OnPauseButtonClick?.Invoke());
        }
    }
}