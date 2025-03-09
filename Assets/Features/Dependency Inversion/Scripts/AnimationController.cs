// AnimationController.cs
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>(); // Ensure Animator is assigned
    }

    public void PlayHit()
    {
        _animator.SetTrigger("Hit"); // Trigger "Hit" animation
    }
    public void PlayAttack()
    {
        _animator.SetTrigger("Attack"); // Trigger "Hit" animation
    }
}