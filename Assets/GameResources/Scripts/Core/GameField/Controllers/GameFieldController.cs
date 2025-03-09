using System;
using Bravada.Core.Constants;
using Bravada.Core.GameField.Controllers.Interfaces;
using UnityEngine;

namespace Bravada.Core.GameField.Controllers
{
    public class GameFieldController : MonoBehaviour, IMovementOnField
    {
        private Vector2 m_Borders;

        private void Start() //Заменить фмс или точкой
        {
            SetFieldBorders();
        }

        public Vector3 GetPositionOnGround(Vector3 position)
        {
            position.x = Mathf.Clamp(position.x, m_Borders.x, m_Borders.y);
            
            return new Vector3(RoundToNearest(position.x), position.y, RoundToNearest(position.z));
        }

        private void SetFieldBorders()
        {
            m_Borders = new Vector2(GameFieldConstants.StartPoint.x, //+ GameFieldConstants.FieldEdgeLength / 2,
                GameFieldConstants.StartPoint.x +
                GameFieldConstants.FieldEdgeLength * GameFieldConstants.NumberFieldsInWidth
                - GameFieldConstants.FieldEdgeLength);
        }
        
        private float RoundToNearest(float value)
        {
            var test = value + GameFieldConstants.FieldEdgeLength / 2;
            return Mathf.Round(test / GameFieldConstants.FieldEdgeLength) * GameFieldConstants.FieldEdgeLength
                   - GameFieldConstants.FieldEdgeLength / 2;
        }
    }
}