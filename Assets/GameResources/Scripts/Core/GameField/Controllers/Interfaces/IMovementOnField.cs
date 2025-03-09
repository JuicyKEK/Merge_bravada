using UnityEngine;

namespace Bravada.Core.GameField.Controllers.Interfaces
{
    public interface IMovementOnField
    {
        Vector3 GetPositionOnGround(Vector3 position);
    }
}