using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Core.Events
{
    public class EventManager : MonoBehaviour
    {

        private Dictionary<Type, IEventHandlerCollection> _collections = new Dictionary<Type, IEventHandlerCollection>();

        public void Emit<T>(Action<T> evt, string channel="default")
            where T : IEventHandler
        {
            if (!channel.Equals("default"))
            {
                throw new NotImplementedException("Multi channel not supported yet");
            }

            var t = typeof(T);
            if (_collections.ContainsKey(t) == false)
            {
                _collections.Add(t, new EventHandlerCollection<T>());
            }

            var collection = _collections[t];
            collection.Add(evt);
            
        }

        public EventManagerHook<T> CreateHook<T>(T handler, string channel="default")
            where T : IEventHandler
        {
            if (!channel.Equals("default"))
            {
                throw new NotImplementedException("Multi channel not supported yet");
            }
            var hook = new EventManagerHook<T>(handler, _collections, this);
            return hook;

        }

        //public void Check(EventManagerHook<T> hook)
        //{

        //}
    }

    public interface IEventHandlerCollection
    {
        void Add(object evt);
        object[] Get(long latestProcessNumber);
    }

    class EventHandlerCollection<T> : IEventHandlerCollection
        where T : IEventHandler
    {
        private List<NumberedEvent<T>> _events = new List<NumberedEvent<T>>();
        private long _number = 0;
        private int _maxEvents = 500;

        public void Add(object evt)
        {
            _number += 1;
            _events.Add(new NumberedEvent<T>() {
                Evt = (Action<T>)evt,
                Number = _number
            });
            //Debug.Log("Added event number" + _number);

            while (_events.Count >= _maxEvents)
            {
                _events.RemoveAt(0);
            }

        }

        public object[] Get(long latestProcessNumber)
        {

            return _events.Where(e => e.Number > latestProcessNumber).Cast<object>().ToArray();


        }
    }

    class NumberedEvent<T>
        where T : IEventHandler
    {
        public Action<T> Evt { get; set; }
        public long Number { get; set; }
    }

    public class EventManagerHook<T>
        where T : IEventHandler
    {
        public long LatestProcessedNumber { get; private set; }
        private T _handler;
        private Dictionary<Type, IEventHandlerCollection> _collections;
        private EventManager _manager;

        public EventManagerHook(T handler, Dictionary<Type, IEventHandlerCollection> collections, EventManager manager)
        {
            _collections = collections;
            _manager = manager;
            _handler = handler;
        }

        public void CheckForEvents()
        {
            var t = typeof(T);
            if (_collections.ContainsKey(t) == false)
            {
                return; // nothing to do. 
            }

            var collection = _collections[t];
            var messages = collection.Get(LatestProcessedNumber).Select(obj =>
            {
                return (NumberedEvent<T>)obj;
            });
            
            foreach(var msg in messages)
            {
                msg.Evt(_handler);
                LatestProcessedNumber = msg.Number;
            }

        }

    }
}
