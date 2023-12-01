using System;
using System.Collections.Generic;
using UnityEngine;

namespace NicoFramework.Tools.EventCenter
{
    /// <summary>
    /// 消息分发中心
    /// </summary>
    public class EventCenter : IDisposable
    {
        public static readonly EventCenter Default = new EventCenter();

        private bool isDispose = false;

        private readonly Dictionary<Type, List<Action<object>>>
            notifiers = new Dictionary<Type, List<Action<object>>>();

        public void Publish<T>(T message)
        {
            if (isDispose) {
                return;
            }

            Type messageType = typeof(T);
            lock (notifiers) {
                if (notifiers.TryGetValue(messageType, out List<Action<object>> callbacks)) {
                    foreach (var callback in callbacks) {
                        callback(message);
                    }
                }
            }
        }

        public void Receive<T>(Action<T> callback)
        {
            Type messageType = typeof(T);
            if (isDispose) {
                throw new ObjectDisposedException("EventCenter");
            }
            lock (notifiers) {
                if (!notifiers.ContainsKey(messageType)) {
                    notifiers.Add(messageType, new List<Action<object>>());
                }   
                notifiers[messageType].Add(obj => callback((T)obj));
            }
        }
        
        
        public void Dispose()
        {
            lock (notifiers) {
                if (!isDispose) {
                    notifiers.Clear();
                    isDispose = true;
                } 
            }
        }
    }
}
