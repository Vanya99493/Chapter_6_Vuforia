using CharacterModule.CharacterAnimationModule.FactoryModule;
using UnityEngine;

namespace CharacterModule.CharacterAnimationModule
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharactersInitializer _charactersInitializer;

        private void OnEnable()
        {
            _charactersInitializer.InitializeCharacter(this);
        }

        public void StartAnimation(string triggerName)
        {
            _animator.SetTrigger(triggerName);
        }

        public void SetActiveAnimator(bool isActive)
        {
            _animator.enabled = isActive;
        }
    }
}