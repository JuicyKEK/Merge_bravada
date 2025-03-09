using UnityEngine;

namespace Bravada.Core.Characters.Runtime.Controllers
{
    public class CharacterShadowMovementController : MonoBehaviour
    {
        [SerializeField] private GameObject m_CharacterShadow;

        public void SetActiveShadow(bool isActive)
        {
            m_CharacterShadow.SetActive(isActive);
        }

        public void MoveShadow(Vector3 position)
        {
            position.y = 0.1f;
            m_CharacterShadow.transform.position = position;
        }
    }
}