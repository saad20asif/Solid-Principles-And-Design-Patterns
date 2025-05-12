using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private HealthBar _playerHealthBarPrefab;
    [SerializeField] private HealthBar _enemyHealthBarPrefab;
    [SerializeField] private Transform _playerUIParent;
    [SerializeField] private Transform _enemyUIParent;

    public override void InstallBindings()
    {
        // Health system (shared)
        Container.Bind<IHealth>().To<Health>().AsTransient()
            .WithArguments(100); // Initial health value

        // Player health bar (specific instance)
        Container.Bind<HealthBar>().WithId("PlayerHealthBar")
            .FromComponentInNewPrefab(_playerHealthBarPrefab)
            .UnderTransform(_playerUIParent) // Parent to UI canvas
            .AsCached();
        
        // Enemy health bar (specific instance)
        Container.Bind<HealthBar>().WithId("EnemyHealthBar")
            .FromComponentInNewPrefab(_enemyHealthBarPrefab)
            .UnderTransform(_enemyUIParent) // Parent to UI canvas
            .AsCached();

        // Player/Enemy bindings
        //Container.BindInterfacesAndSelfTo<Player>().FromComponentInHierarchy().AsSingle();
        //Container.BindInterfacesAndSelfTo<Enemy>().FromComponentInHierarchy().AsSingle();
    }
}