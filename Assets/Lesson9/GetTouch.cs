using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetTouch : MonoBehaviour {
    public NetworkClient client = null;
    public GameObject ip_advice;
    public Text t;
    public GameObject join;
    public GameObject ip_text;
    public GameObject shot_button;
    public GameObject calibration_button;
    public GameObject disconnect_button;
    public string MasterServerIpAddress="127.0.0.1";
    public int MasterServerPort=7777;


    public bool isConnected = false;

    void Awake()
    {
        Input.gyro.enabled = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

	void Update () {
        if (client != null&&isConnected)
        {
            var msg = new MyMessageTypes.SynchronizationMessage();
            msg.q = new Vector4(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w);
            client.Send(MyMessageTypes.synch, msg);
        }
	}
    public void InitializeClient()
    {
        if (client != null&&isConnected)
        {
            Debug.LogError("Already connected");
            return;
        }
        MasterServerIpAddress = ip_text.GetComponentInChildren<Text>().text;
        client = new NetworkClient();
        client.Connect(MasterServerIpAddress, MasterServerPort);

        client.RegisterHandler(MsgType.Connect, OnClientConnect);
        client.RegisterHandler(MsgType.Disconnect, OnClientDisconnect);
        client.RegisterHandler(MsgType.Error, OnClientError);

        DontDestroyOnLoad(gameObject);
    }

    void OnClientConnect(NetworkMessage netMsg)
    {
        Debug.Log("Client Connected");

        ip_advice.SetActive(false);
        ip_text.SetActive(false);
        join.SetActive(false);
        shot_button.SetActive(false);

        calibration_button.SetActive(true);
        disconnect_button.SetActive(true);
        isConnected = true;
    }

    void OnClientDisconnect(NetworkMessage netMsg)
    {
        Debug.Log("Client Disconnect");
        shot_button.SetActive(false);
        calibration_button.SetActive(false);
        disconnect_button.SetActive(false);

        ip_advice.SetActive(true);
        ip_text.SetActive(true);
        join.SetActive(true);

        isConnected = false;
        client = null;
    }

    void OnClientError(NetworkMessage netMsg)
    {
        Debug.Log("ClientError from Master");
        OnFailedToConnectToMasterServer();
        disconnect_button.SetActive(false);
        client = null;
        isConnected = false;
    }

    public void TouchDone()
    {
        var msg = new MyMessageTypes.TouchMessage();
        msg.isTouched = true;
        client.Send(MyMessageTypes.touch, msg);
    }



    public void Confirm()
    {
        shot_button.SetActive(true);
        var msg = new MyMessageTypes.Calibration();
        client.Send(MyMessageTypes.calibration,msg );
        calibration_button.SetActive(false);
    }

    public void Disconnect()
    {
        client.Disconnect();
        shot_button.SetActive(false);
        calibration_button.SetActive(false);
        disconnect_button.SetActive(false);

        ip_advice.SetActive(true);
        ip_text.SetActive(true);
        join.SetActive(true);

        isConnected = false;
        client = null;
    }

    public virtual void OnFailedToConnectToMasterServer()
    {
        Debug.Log("OnFailedToConnectToMasterServer");
    }
}
