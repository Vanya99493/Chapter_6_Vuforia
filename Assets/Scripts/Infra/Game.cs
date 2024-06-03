using System.Linq;
using Assets.Scripts.Infra.PauseModule;
using AudioModule;
using CharacterModule.CharacterAnimationModule;
using ScriptableObjects;
using UIModule;
using UIModule.TestingModule;
using UnityEngine;

namespace Infra
{
    public class Game : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private AnimationSoundConfig _animationSoundConfig;

        [Header("Components")]
        [SerializeField] private CharactersAnimationService _charactersAnimationService;
        [SerializeField] private AudioController _audioController;
        [SerializeField] private UIController _uiController;
        [SerializeField] private PauseController _pauseController;
        
        private void Awake()
        {
            _audioController.Initialize(_animationSoundConfig.SoundsByTriggerName.Values.ToArray());
            _charactersAnimationService.Initialize(_animationSoundConfig.SoundsByTriggerName.Keys.ToArray());
            _uiController.Initialize(
                OnPauseButtonClick,
                OnIncreaseButtonClick,
                OnDecreaseButtonClick
                );
            _uiController.DeactivateUI();
            _charactersAnimationService.AddNewCharacterEvent += OnAddNewCharacter;
        }

        private void OnAddNewCharacter()
        {
            if (_charactersAnimationService.SpawnedCharacters == 1)
            {
                _audioController.StartAudio();
                _uiController.ActivateUI();
            }
        }

        private void OnPauseButtonClick()
        {
            _pauseController.SwitchPause();
            _charactersAnimationService.SetPause(_pauseController.IsPaused);
            _uiController.SetPause(_pauseController.IsPaused);
            _audioController.SetPause(_pauseController.IsPaused);
        }

        private void OnIncreaseButtonClick()
        {
            _charactersAnimationService.ChangeAnimation(1);
            _audioController.ChangeAudioClip(1);
        }

        private void OnDecreaseButtonClick()
        {
            _charactersAnimationService.ChangeAnimation(-1);
            _audioController.ChangeAudioClip(-1);
        }
    }
}