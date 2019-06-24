using UnityEngine;

public class KeyDebugManagerSample : MonoBehaviour
{
    protected virtual void OnGUI()
    {
        KeyDebugManager manager = KeyDebugManager.Instance;

        foreach (var keyDebugInfo in manager.KeyDebugInfos)
        {
            string keyLabel = keyDebugInfo.key.ToString() + " : ";
            var debugs      = keyDebugInfo.debugs;
            int debugsCount = debugs.GetPersistentEventCount();

            for (int i = 0; i < debugsCount; i++)
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