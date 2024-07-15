namespace UralHedgehog
{
    namespace UI
    {
        public class UIManager
        {
            private readonly UIRoot _uiRoot;
            
            public UIManager(UIRoot uiRoot)
            {
                _uiRoot = uiRoot;
            }

            #region Open

            /// <summary>
            /// Поднимает виджет с моделью IExample
            /// </summary>
            public void OpenViewExample(IExample example)
            {
                _uiRoot.Create(nameof(WExample), example);
            }
            
            /// <summary>
            /// Поднимает пустой виджет (без модели)
            /// Для этого используем данную конструкцию (IEmptyWidget, модель null)
            /// </summary>
            public void OpenViewExampleEmpty()
            {
                _uiRoot.Create<IEmptyWidget>(nameof(WExampleEmpty), null);
            }

            #endregion

            //TODO: Методы Close могут понадобиться для принудительного закрытия виджета, либо если виджет не имеет кнопки закрыть.
            //TODO: Его можно закрыть и уничтожить из любого места.
            #region Close

            /// <summary>
            /// Уничтожает виджет с моделью IExample
            /// </summary>
            public void CloseViewExample()
            {
                _uiRoot.Kill(nameof(WExample));
            }

            #endregion
        }
    }
}