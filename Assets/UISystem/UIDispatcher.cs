using System;

namespace UralHedgehog
{
    namespace UI
    {
        public static class UIDispatcher
        {
            #region Events

            public static event Action<object> ShowWidget;
            public static event Action<object> HideWidget;
            public static event Action<object> Kill;

            #endregion

            #region ActionsEvent

            private static Action GetEvent(Event e)
            {
                throw e switch
                {
                    _ => new ArgumentOutOfRangeException(nameof(e), e, null)
                };
            }

            #endregion

            #region ActionsEventHasParam

            private static Action<object> GetEventHasParam(Event e)
            {
                return e switch
                {
                    Event.SHOW_WIDGET => ShowWidget,
                    Event.HIDE_WIDGET => HideWidget,
                    Event.KILL => Kill,
                    
                    _ => throw new ArgumentOutOfRangeException(nameof(e), e, null)
                };
            }

            #endregion

            #region Send

            /// <summary>
            /// Отправка события без параметров
            /// </summary>
            /// <param name="e">Событие</param>
            public static void Send(Event e)
            {
                Invoker(GetEvent(e));
            }

            /// <summary>
            /// Отправка события с одним параметром любого типа
            /// </summary>
            /// <param name="e">Событие</param>
            /// <param name="arg">Параметр</param>
            public static void Send(Event e, object arg)
            {
                Invoker(GetEventHasParam(e), arg);
            }

            /// <summary>
            /// Отправка события с массивом параметров любого типа
            /// </summary>
            /// <param name="e">Событие</param>
            /// <param name="args">Массив параметров</param>
            public static void Send(Event e, params object[] args)
            {
                Invoker(GetEventHasParam(e), args);
            }

            private static void Invoker(Action action)
            {
                action?.Invoke();
            }

            private static void Invoker(Action<object> action, object arg)
            {
                action?.Invoke(arg);
            }

            private static void Invoker(Action<object> action, params object[] args)
            {
                action?.Invoke(args);
            }

            #endregion
        }

        public enum Event
        {
            SHOW_WIDGET,
            HIDE_WIDGET,
            KILL,
        }
    }
}