using Zenject; // Import Extenject namespace

// GameInstaller is a MonoInstaller, meaning it's a Unity component that sets up bindings.
public class GameInstaller : MonoInstaller
{

    // Override the InstallBindings method to define dependency bindings.
    public override void InstallBindings()
    {

        // Bind AnimationController:
        // - FromComponentInHierarchy(): Look for an AnimationController in the scene.
        // - AsSingle(): Ensure only one instance exists (singleton).
        Container.Bind<AnimationController>().FromComponentInHierarchy().AsSingle();

        // Bind IWeapon to Sword:
        // - To<Sword>(): Use the Sword class when IWeapon is requested.
        // - AsTransient(): Create a new instance every time IWeapon is injected.
        Container.Bind<IWeapon>().To<Sword>().AsTransient();

        // Bind IHealth to Health:
        // - To<Health>(): Use the Health class when IHealth is requested.
        // - AsSingle(): Ensure only one instance exists (singleton).
        //Container.Bind<IHealth>().To<Health>().AsSingle();

        // Bind Player:
        // - FromComponentInHierarchy(): Look for a Player component in the scene.
        // - AsSingle(): Ensure only one instance exists (singleton).
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
    }
}