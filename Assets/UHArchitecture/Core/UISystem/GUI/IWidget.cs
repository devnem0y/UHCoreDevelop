using System;

namespace UralHedgehog
{
    namespace UI
    {
        public interface IWidget
        {
            public string Name { get; }
            
            public event Action<IWidget> hide;
            
            void Hide();
        }
    }
}