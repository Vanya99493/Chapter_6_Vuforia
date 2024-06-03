using CharacterModule.CharacterAnimationModule.FactoryModule;
using System;
using UnityEngine;

namespace CharacterModule.CharacterAnimationModule
{
    public class CharactersAnimationService : MonoBehaviour
    {
        public event Action AddNewCharacterEvent;

        [SerializeField] private CharactersInitializer _charactersInitializer;

        private CharactersAnimationController _charactersAnimationController;
        
        public int SpawnedCharacters => _charactersAnimationController.CharactersCount;
        
        public void Initialize(string[] animationsTriggers)
        {
            _charactersAnimationController = new CharactersAnimationController(animationsTriggers);
            _charactersInitializer.InitializeCharacterAnimControllerEvent += AddNewCharacter;
        }

        public void AddNewCharacter(CharacterAnimatorController characterAnimController)
        {
            _charactersAnimationController.AddCharacterAnimatorController(characterAnimController);
            AddNewCharacterEvent?.Invoke();
        }

        public void ChangeAnimation(int index)
        {
            _charactersAnimationController.ChangeAnimation(index);
        }

        public void SetPause(bool isPaused)
        {
            _charactersAnimationController.SetPause(isPaused);
        }
    }
}