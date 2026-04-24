using UnityEngine;
using R3;
using System;
using GameResources.Scripts.Core.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Bravada.Core.MovementCharacters.Controllers
{
    public class ObjectMover : IDisposable, IStartable
    {
        private IMovementObject m_CurrentObject;
        private CompositeDisposable m_Disposables = new();
        private IInputSystem m_InputSystem;
        private Camera m_MainCamera;
        
        public ObjectMover(Camera mainCamera, IInputSystem inputSystem)
        {
            m_MainCamera = mainCamera;
            m_InputSystem = inputSystem;

            SetupInputHandling();
        }
        
        public void Start()
        {
            //нужен, пока не вызываю класс в других местах 
        }
        
        private void SetupInputHandling()
        {
            m_MainCamera = Camera.main;
            
            m_InputSystem.OnMouseLeftDown
                .Select(_ => GetObjectUnderMouse())
                .Where(obj => obj != null)
                .Subscribe(obj =>
                {
                    m_CurrentObject = obj;
                    obj.StartMovement();
                })
                .AddTo(m_Disposables);
            
            m_InputSystem.OnMouseLeftUp
                .Where(_ => m_CurrentObject != null)
                .Subscribe(_ =>
                {
                    m_CurrentObject.EndMovement();
                    m_CurrentObject = null;
                })
                .AddTo(m_Disposables);
            
            m_InputSystem.OnMouseLeftHold
                .Where(_ => m_CurrentObject != null)
                .Select(_ => GetHitPoint())
                .Where(point => point.HasValue)
                .Subscribe(point =>
                {
                    m_CurrentObject.MoveTo(point.Value);
                })
                .AddTo(m_Disposables);
        }
        
        private IMovementObject GetObjectUnderMouse()
        {
            Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                return hit.collider.GetComponent<IMovementObject>();
            }
            return null;
        }
        
        private Vector3? GetHitPoint()
        {
            Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                return hit.point;
            }
            return null;
        }

        public void Dispose()
        {
            m_Disposables?.Dispose();
        }
    }
}