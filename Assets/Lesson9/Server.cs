using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Server : MonoBehaviour
{
    public int MasterServerPort;
    public GameObject calibration_crosshair;
    public GameObject playerPrefab;
    public List<Client> clients = new List<Client>();
    void Awake()
    {
        InitializeServer();
    }
    public void InitializeServer()
    {
        if (NetworkServer.active)
        {
            Debug.LogError("Already Initialized");
            return;
        }

        NetworkServer.Listen(MasterServerPort);

        // system msgs
        NetworkServer.RegisterHandler(MsgType.Connect, OnServerConnect);
        NetworkServer.RegisterHandler(MsgType.Disconnect, OnServerDisconnect);
        NetworkServer.RegisterHandler(MsgType.Error, OnServerError);

        NetworkServer.RegisterHandler(MyMessageTypes.synch, Synch);
        NetworkServer.RegisterHandler(MyMessageTypes.touch, TouchAction);
        NetworkServer.RegisterHandler(MyMessageTypes.calibration, Calibration);

        DontDestroyOnLoad(gameObject);
    }

    void Synch(NetworkMessage netMsg)
    {
        Vector4 rot = netMsg.reader.ReadVector4();
        Client cl = clients.Find(x => x.addres == netMsg.channelId);
        cl.scene_object.GetComponent<Crosshair>().client_rot = new Quaternion(rot.x, rot.y, rot.z, rot.w);
    }

    void Calibration(NetworkMessage netMsg)
    {
        calibration_crosshair.SetActive(false);
    }

    void TouchAction(NetworkMessage netMsg)
    {
        Client cl= clients.Find(x => x.addres == netMsg.channelId);
        cl.scene_object.GetComponent<Crosshair>().Shot();
    }

    int i = 1;

    void OnServerConnect(NetworkMessage netMsg)
    {
        Debug.Log("Client connect:" + netMsg.conn.address);
        Client cl = new Client();
        cl.addres = netMsg.channelId;
        Object go = Instantiate(playerPrefab,Vector3.zero,Quaternion.identity);
        go.name = "Client" + i;
        i++;
        cl.scene_object = (GameObject)go;
        clients.Add(cl);
    }

    void OnServerDisconnect(NetworkMessage netMsg)
    {
        Debug.Log("Server disconnect"+netMsg.channelId);
        i--;
        Client cl=clients.Find(x => x.addres == netMsg.channelId);
        Destroy(cl.scene_object);
        clients.Remove(cl);
    }

    void OnServerError(NetworkMessage netMsg)
    {
        Debug.Log("Server error");
        NetworkServer.DisconnectAll();
    }
}
