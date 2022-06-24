using UnityEngine;

public class KeyDebugManagerSample : MonoBehaviour
{
    protected virtual void OnGUI()
    {
        var manager = KeyDebugManager.Instance;

        foreach (var keyDebugInfo in manager.KeyDebugInfos)
        {
            var keyLabel    = keyDebugInfo.key + " : ";
            var debugs      = keyDebugInfo.debugs;
            var debugsCount = debugs.GetPersistentEventCount();

            for (var i = 0; i < debugsCount; i++)
            {
                GUILayout.Label(keyLabel + debugs.GetPersistentMethodName(i));
            }
        }
    }

    public void SampleMethodA()
    {
        Debug.Log("SampleMethodA");
    }

    public void SampleMethodB()
    {
        Debug.Log("SampleMethodB");
    }

    public void SampleMethodC()
    {
        Debug.Log("SampleMethodC");
    }
}