﻿using System;

namespace UralHedgehog
{
    /// <summary>
    /// Добавить событие в enum, затем в регион Events
    /// После сделать зависимость в нужном из регионов (ActionsEvent / ActionsEventHasParam)
    /// Если событие имеет параметр, то всегда передается object (Action<object>)
    /// </summary>
    public class Dispatcher
    {
        #region Events

        // SYSTEM Не игровые события, а глобальные для проекта
        public static event Action SystemLoading;
        public static event Action SystemLaunch;
        public static event Action SystemBegin;
        public static event Action SystemLocalize;

        #endregion

        #region ActionsEvent

        private static Action GetEvent(Event e)
        {
            return e switch
            {
                Event.SYSTEM_LOADING => SystemLoading,
                Event.SYSTEM_LAUNCH => SystemLaunch,
                Event.SYSTEM_BEGIN => SystemBegin,
                Event.SYSTEM_LOCALIZE => SystemLocalize,
                
                _ => throw new ArgumentOutOfRangeException(nameof(e), e, null)
            };
        }

        #endregion

        #region ActionsEventHasParam

        private static Action<object> GetEventHasParam(Event e)
        {
            throw e switch
            {
                _ => new ArgumentOutOfRangeException(nameof(e), e, null)
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
        // SYSTEM Не игровые события, а глобальные для проекта
        SYSTEM_LOADING,
        SYSTEM_LAUNCH,
        SYSTEM_BEGIN,
        SYSTEM_LOCALIZE,
    }
}