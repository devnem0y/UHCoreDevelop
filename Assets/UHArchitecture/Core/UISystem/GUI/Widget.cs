using System;
using UnityEngine;

namespace UralHedgehog
{
    namespace UI
    {
        public abstract class Widget<T> : MonoBehaviour, IWidget
        {
            [SerializeField] private Type _type;
            public Type Type => _type;

            public string Name => transform.name;

            private Transform _wrapper;

            protected T Model { get; private set; }

            public event Action<IWidget> hide;
            
            protected virtual void Awake()
            {
                _wrapper = transform.GetChild(0);
                _wrapper.localScale = Vector3.zero;
            }

            /// <summary>
            /// Base не удалять, даже если модель пустая!
            /// Все что нужно писать после.
            /// </summary>
            public virtual void Init(T model)
            {
                Model = model;
            }

            public virtual void Show()
            {
                _wrapper.localScale = Vector3.one;
            }

            public virtual void Hide()
            {
                hide?.Invoke(this);
                Destroy(gameObject);
            }
        }

        public enum Type
        {
            PANEL = 0,
            WINDOW = 1,
        }
    }
}