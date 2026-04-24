using Bravada.Core.Characters.Runtime.Controllers;
using Bravada.Core.GameField.Controllers.Interfaces;
using Bravada.Core.MovementCharacters.Controllers;
using UnityEngine;
using VContainer;

namespace Bravada.Core.Characters
{
    public class CharacterMovementController : MonoBehaviour, IMovementObject //переименовать и убирать рейкаст на момент перемещения
    {
        [SerializeField] private CharacterShadowMovementController m_CharacterShadow;
        [SerializeField] private Collider m_Collider;

        private IMovementOnField m_MovementOnField;
        private Vector3 m_Velocity = Vector3.zero;
        
        public int LevelMerge { get; set; }
        public string CharacterKey { get; set; }

        [Inject]
        public void Init(IMovementOnField movementOnField)
        {
            m_MovementOnField = movementOnField;
        }

        public void StartMovement()
        {
            m_CharacterShadow.SetActiveShadow(true);
            transform.position += Vector3.up * 1.5f;
            m_Collider.enabled = false;
        }

        public void MoveTo(Vector3 position) //Надо отдельно калькулировать ограничение движения для персонажа
        {
            position.y = transform.position.y;
            m_CharacterShadow.MoveShadow(m_MovementOnField.GetPositionOnGround(position));
            transform.position = Vector3.SmoothDamp(transform.position, position, ref m_Velocity, 0.1f);
        }

        public void EndMovement()
        {
            m_Collider.enabled = true;
            transform.position -= Vector3.up  * 1.5f;
            transform.position = m_MovementOnField.GetPositionOnGround(transform.position);
            m_CharacterShadow.SetActiveShadow(false);
        }
    }
}
