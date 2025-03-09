using UnityEngine;

namespace Bravada.Core.Constants
{
    public class GameFieldConstants
    {
        public const float FieldEdgeLength = 2f;
        public const int NumberFieldsInWidth = 7;
        
        private static Vector3 m_StartPoint = new Vector3(0f, 0f, 0f);
        
        public static Vector3 StartPoint => m_StartPoint;
    }
}