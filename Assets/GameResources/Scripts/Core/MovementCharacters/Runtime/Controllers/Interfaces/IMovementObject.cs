using UnityEngine;

namespace Bravada.Core.MovementCharacters.Controllers
{
    public interface IMovementObject
    {
        void StartMovement();
        void MoveTo(Vector3 position);
        void EndMovement();
    }
}