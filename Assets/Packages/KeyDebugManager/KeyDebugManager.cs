using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

public class KeyDebugManager : SingletonMonoBehaviour<KeyDebugManager>
{
    // NOTE:
    // If set KeyCode.None, it will be called in every frame.

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

    protected override void Awake()
    {
        base.Awake();
        KeyDebugInfos = new ReadOnlyCollection<KeyDebugInfo>(keyDebugInfos);
    }

    private void Update()
    {
        foreach (var keyDebugInfo in keyDebugInfos)
        {
            if (Input.GetKeyDown(keyDebugInfo.key) || keyDebugInfo.key == KeyCode.None)
            {
                keyDebugInfo.debugs.Invoke();
            }
        }
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}