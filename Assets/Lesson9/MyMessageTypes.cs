using UnityEngine;
using UnityEngine.Networking;

public class MyMessageTypes : MonoBehaviour
{
    public const short synch = 170;
    public const short touch = 171;
    public const short calibration = 172;

    public class SynchronizationMessage : MessageBase
    {
        public Vector4 q;
    }

    public class TouchMessage : MessageBase
    {
        public bool isTouched;
    }

    public class Calibration : MessageBase
    {

    }
}
