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
        _slider.maxValue = _health.CurrentHealth;
        _slider.value = _health.CurrentHealth;
    }

    private void UpdateHealth(int newHealth)
    {
        _slider.value = newHealth;
    }

    private void OnDestroy()
    {
        if (_health != null)
            _health.OnHealthChanged -= UpdateHealth;
    }
}