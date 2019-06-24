using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

public class KeyDebugManager : SingletonMonoBehaviour<KeyDebugManager>
{
    [System.Serializable]
    public class KeyDebugInfo
    {
        public KeyCode    key;
        public UnityEvent debugs;
    }

    [SerializeField]
    protected KeyDebugInfo[] keyDebugInfos;

    public ReadOnlyCollection<KeyDebugInfo> KeyDebugInfos
    {
        get; protected set;
    }

    protected virtual void Start()
    {
        this.KeyDebugInfos = new ReadOnlyCollection<KeyDebugInfo>(this.keyDebugInfos);
    }

    protected virtual void Update()
    {
        foreach (var keyDebugInfo in this.keyDebugInfos)
        {
            if (Input.GetKeyDown(keyDebugInfo.key))
            {
                keyDebugInfo.debugs.Invoke();
            }
        }
    }
}