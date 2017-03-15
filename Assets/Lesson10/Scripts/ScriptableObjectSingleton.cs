using UnityEngine;

[CreateAssetMenu(fileName = "Singleton", menuName = "ScriptableObjects/Singleton")]
public class ScriptableObjectSingleton : ScriptableObject {
    private static ScriptableObjectSingleton instance_;
    public static ScriptableObjectSingleton Instance {
        get
        {
            if (!instance_)
            {
                ScriptableObjectSingleton[] temp = Resources.FindObjectsOfTypeAll<ScriptableObjectSingleton>();
                if (temp.Length>0)
                    instance_ = Resources.FindObjectsOfTypeAll<ScriptableObjectSingleton>()[0];
            }
            if (!instance_)
            {
                Debug.Log("Not found");
                instance_ = CreateInstance<ScriptableObjectSingleton>();
            }
               return instance_;
        }
    }
}
