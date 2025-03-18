using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Player _player; // Assign in Inspector
    [SerializeField] private Enemy _enemy;   // Assign in Inspector

    public override void InstallBindings()
    {
        print("GameInstaller: InstallBindings started");
        // Create a new instance of Health for every class that asks for an IHealth
        Container.Bind<IHealth>().To<Health>().AsTransient();
        //// Bind Player
        //Container.Bind<IHealth>().To<Health>().AsSingle(); // Player health
        //Container.Bind<Player>().FromInstance(_player).AsSingle(); // Player instance
        //Container.Bind<HealthBar>().FromComponentInChildren().WhenInjectedInto<Player>(); // Player HealthBar
        //print("GameInstaller: Player bindings completed");

        //// Bind Enemy
        //Container.Bind<IHealth>().To<Health>().FromNew().AsSingle(); // Enemy health
        //Container.Bind<Enemy>().FromInstance(_enemy).AsSingle(); // Enemy instance
        //Container.Bind<HealthBar>().FromComponentInChildren().WhenInjectedInto<Enemy>(); // Enemy HealthBar
        //print("GameInstaller: Enemy bindings completed");

        //print("GameInstaller: InstallBindings completed");
    }
}