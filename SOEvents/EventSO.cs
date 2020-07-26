using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO.Events
{
    [CreateAssetMenu(fileName = "SOEvent", menuName = "SO/Event")]
    public class EventSO : ScriptableObject
    {

        public List<SOListener> listeners = new List<SOListener>();

        [TextArea]
        [Tooltip("When is this event raised")]
        public string eventDescription = "[When does this event trigger]";

        public IVariableSO Value;
        public void Raise()
        {
            Debug.Log("Raise: " + name);
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].Response.Invoke();
        }

        public void RegisterListener(SOListener listener )
        {
            if (!listeners.Contains(listener))
            {
                Debug.LogWarning("register: " + listener.source.gameObject.name + " on "+ name);
                listeners.Add(listener);
            }
        }
        public void UnregisterListener(SOListener listener)
        {
            if (listeners.Contains(listener))
            {
                Debug.LogWarning("unregister: " + listener.source.gameObject.name + " on " + name);
                listeners.Remove(listener);
            }
        }

        public void Awake()
        {
            listeners = new List<SOListener>();
        }
        public void OnAfterDeserialize()
        {
            listeners = new List<SOListener>();
        }

        public void OnBeforeSerialize() {
            listeners = new List<SOListener>();
        }
    }
}


