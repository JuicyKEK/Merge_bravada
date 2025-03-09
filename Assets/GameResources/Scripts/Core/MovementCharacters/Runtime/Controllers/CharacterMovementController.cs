using UnityEngine;

namespace Bravada.Core.MovementCharacters.Controllers
{
    public class CharacterMovementController: MonoBehaviour
    {
        private IMovementObject m_CurrentObject;
        private Camera m_MainCamera;

        void Start() //мб старт и апдаты заменить на тикеты
        {
            m_MainCamera = Camera.main;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    IMovementObject movable = hit.collider.GetComponent<IMovementObject>();
                    if (movable != null)
                    {
                        m_CurrentObject = movable;
                        m_CurrentObject.StartMovement();
                    }
                }
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                if (m_CurrentObject != null)
                {
                    m_CurrentObject.EndMovement();
                }
                
                m_CurrentObject = null;
            }
            
            if (Input.GetMouseButton(0) && m_CurrentObject != null)
            {
                Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    m_CurrentObject.MoveTo(hit.point);
                }
            }
        }
    }
}