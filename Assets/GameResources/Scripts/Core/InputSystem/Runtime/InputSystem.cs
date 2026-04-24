using UnityEngine;
using R3;

namespace GameResources.Scripts.Core.InputSystem
{
    
    public class InputSystem : IInputSystem
    {
        public Observable<Unit> OnMouseLeftDown { get; private set; }
        public Observable<Unit> OnMouseLeftUp { get; private set; }
        public Observable<bool> OnMouseLeftHold { get; private set; }
    
        public InputSystem()
        {
            OnMouseLeftDown = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Share();
        
            OnMouseLeftUp = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonUp(0))
                .Share();
        
            OnMouseLeftHold = Observable.EveryUpdate()
                .Select(_ => Input.GetMouseButton(0))
                .Share();
        }
    }

}