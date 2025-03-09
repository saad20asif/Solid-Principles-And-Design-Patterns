using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private IHealth _health;

    public void Initialize(IHealth health)
    {
        _health = health;
        _health.OnHealthChanged += UpdateHealth;
        UpdateHealth(_health.CurrentHealth); // Initialize UI
    }

    private void UpdateHealth(int health)
    {
        _slider.value = health;
    }
}