using Bravada.Core.MovementCharacters.Controllers;
using UnityEngine;

namespace Bravada.Core.Characters
{
    public class CharacterMovementController : MonoBehaviour, ICharacter, IMovementObject
    {
        private Vector3 m_Velocity = Vector3.zero;
        
        public int LevelMerge { get; set; }
        public string CharacterKey { get; set; }

        public void MergeCharacters(ICharacter character)
        {
            
        }

        public void StartMovement()
        {
            transform.position += Vector3.up * 1.5f;
        }

        public void MoveTo(Vector3 position)
        {
            position.y = transform.position.y;
            transform.position = Vector3.SmoothDamp(transform.position, position, ref m_Velocity, 0.1f);
            //transform.position = Vector3.MoveTowards();
        }

        public void EndMovement()
        {
            transform.position -= Vector3.up  * 1.5f;
            transform.position = CalculatingPositionOnGround(transform.position);
        }

        private Vector3 CalculatingPositionOnGround(Vector3 position)
        {
            
        }
    }
}
