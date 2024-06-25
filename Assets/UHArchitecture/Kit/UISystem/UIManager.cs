namespace UralHedgehog
{
    namespace UI
    {
        public class UIManager
        {
            private readonly UIHandler _uiHandler;
            
            private readonly ISettings _settings;
            
            public UIManager(UIHandler uiHandler, ISettings settings)
            {
                _uiHandler = uiHandler;
                
                _settings = settings;
            }

            #region Open

            /// <summary>
            /// Поднимает виджет настроек
            /// </summary>
            public void OpenViewSettings()
            {
                _uiHandler.Create(nameof(WSettings), _settings);
            }

            #endregion

            //TODO: Методы Close могут понадобиться для принудительного закрытия виджета, либо если виджет не имеет кнопки закрыть.
            //TODO: Его можно закрыть и уничтожить из любого места.
            #region Close

            /// <summary>
            /// Уничтожает виджет настроек
            /// </summary>
            public void CloseViewSettings()
            {
                _uiHandler.Kill(nameof(WSettings));
            }

            #endregion
        }
    }
}