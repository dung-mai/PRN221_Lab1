using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWFPApp
{
    public class EventAggregator
    {
        private static readonly Lazy<EventAggregator> instance = new Lazy<EventAggregator>(() => new EventAggregator());

        public static EventAggregator Instance => instance.Value;

        private readonly Dictionary<string, List<Action<object>>> subscribers = new Dictionary<string, List<Action<object>>>();

        public void Subscribe(string message, Action<object> action)
        {
            if (!subscribers.TryGetValue(message, out var actions))
            {
                actions = new List<Action<object>>();
                subscribers[message] = actions;
            }

            actions.Add(action);
        }

        public void Unsubscribe(string message, Action<object> action)
        {
            if (subscribers.TryGetValue(message, out var actions))
            {
                actions.Remove(action);
            }
        }

        public void Publish(string message, object payload)
        {
            if (subscribers.TryGetValue(message, out var actions))
            {
                foreach (var action in actions)
                {
                    action(payload);
                }
            }
        }
    }
}
