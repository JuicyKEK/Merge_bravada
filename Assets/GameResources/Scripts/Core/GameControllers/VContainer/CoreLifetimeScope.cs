using Bravada.Core.Characters;
using Bravada.Core.GameField.Controllers;
using Bravada.Core.GameField.Controllers.Interfaces;
using Bravada.Core.MovementCharacters.Controllers;
using GameResources.Scripts.Core.InputSystem;
using VContainer;
using VContainer.Unity;

public class CoreLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<GameFieldController>().As<IMovementOnField>();
        builder.RegisterComponentInHierarchy<InputSystem>().As<IInputSystem>();
        //builder.RegisterComponentInHierarchy<ObjectMover>();
        builder.RegisterComponentInHierarchy<Bravada.Core.Characters.CharacterMovementController>().As<IMovementObject>();
    }
}
