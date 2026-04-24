using Bravada.Core.Characters;
using Bravada.Core.GameField.Controllers;
using Bravada.Core.GameField.Controllers.Interfaces;
using Bravada.Core.MovementCharacters.Controllers;
using GameResources.Scripts.Core.InputSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class CoreLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<GameFieldController>().As<IMovementOnField>();
        builder.RegisterComponentInHierarchy<CharacterMovementController>().As<IMovementObject>();
        
        builder.RegisterComponent(Camera.main);
        builder.RegisterEntryPoint<InputSystem>().As<IInputSystem>();
        builder.RegisterEntryPoint<ObjectMover>();
    }
}
