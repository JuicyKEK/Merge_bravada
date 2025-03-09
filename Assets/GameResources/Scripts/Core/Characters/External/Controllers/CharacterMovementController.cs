using Bravada.Core.Characters.Runtime.Controllers;
using Bravada.Core.GameField.Controllers;
using Bravada.Core.MovementCharacters.Controllers;
using UnityEngine;

namespace Bravada.Core.Characters
{
    public class CharacterMovementController : MonoBehaviour, IMovementObject
    {
        [SerializeField] private GameFieldController m_GameFieldController; //Потом инжектить интерфейс IMovementOnField
        [SerializeField] private CharacterShadowMovementController m_CharacterShadow;
        
        private Vector3 m_Velocity = Vector3.zero;
        
        public int LevelMerge { get; set; }
        public string CharacterKey { get; set; }

        public void StartMovement()
        {
            m_CharacterShadow.SetActiveShadow(true);
            transform.position += Vector3.up * 1.5f;
        }

        public void MoveTo(Vector3 position) //Надо отдельно калькулировать ограничение движения для персонажа
        {
            position.y = transform.position.y;
            m_CharacterShadow.MoveShadow(m_GameFieldController.GetPositionOnGround(position));
            transform.position = Vector3.SmoothDamp(transform.position, position, ref m_Velocity, 0.1f);
        }

        public void EndMovement()
        {
            transform.position -= Vector3.up  * 1.5f;
            transform.position = m_GameFieldController.GetPositionOnGround(transform.position);
            m_CharacterShadow.SetActiveShadow(false);
        }
    }
}
