using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _playerDamage = 10;
    [SerializeField] private int _enemyDamage = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _enemy.ApplyDamage(_playerDamage); // Player attacks enemy
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _player.ApplyDamage(_enemyDamage); // Enemy attacks player
        }
    }
}