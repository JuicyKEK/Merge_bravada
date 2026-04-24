using R3;
using UnityEngine;

namespace GameResources.Scripts.Core.InputSystem
{
    public interface IInputSystem
    {
        public Observable<Unit> OnMouseLeftDown { get;  }
        public Observable<Unit> OnMouseLeftUp { get; }
        public Observable<bool> OnMouseLeftHold { get;  }
    }
}