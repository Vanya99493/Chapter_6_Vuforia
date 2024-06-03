using System;
using UnityEngine;

namespace CharacterModule.CharacterAnimationModule.FactoryModule
{
    public class CharactersInitializer : MonoBehaviour
    {
        public event Action<CharacterAnimatorController> InitializeCharacterAnimControllerEvent;

        [SerializeField] private Transform _lookAtTransform;

        public void InitializeCharacter(CharacterAnimatorController characterAnimController)
        {
            Vector3 lookAtPosition = _lookAtTransform.position;

            if (lookAtPosition != Vector3.zero)
            {
                lookAtPosition.y = characterAnimController.transform.position.y;
                characterAnimController.transform.LookAt(lookAtPosition);
            }

            InitializeCharacterAnimControllerEvent?.Invoke(characterAnimController);
        }
    }
}