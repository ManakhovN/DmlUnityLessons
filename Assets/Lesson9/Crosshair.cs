using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Crosshair : NetworkBehaviour
{
    private LineRenderer lr;
    public float radius;
    public GameObject crosshair;
    public float reload = 0.5f;
    public float rotationRatio = 3f;
    public Quaternion client_rot;

    private GameObject playerCapsule;
    private GameObject playerWeapon;
    bool readyToShot = true;
    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<LineRenderer>();
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, Vector3.zero);
        Material mat = new Material(Shader.Find("Particles/Additive"));
        mat.color = Color.red;
        lr.material = mat;
        lr.enabled = false;
        playerCapsule = transform.GetChild(1).gameObject;
        playerWeapon = transform.GetChild(2).gameObject;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        playerWeapon.transform.rotation = client_rot;
        playerCapsule.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Vector3 v3 = client_rot * Vector3.forward * radius;
        crosshair.transform.position = v3;
        crosshair.transform.LookAt(transform.position);
    }

    public void Shot()
    {
        if (readyToShot)
        {
            Ray ray = new Ray();
            lr.enabled = true;

            ray.origin = transform.position;
            ray.direction = playerWeapon.transform.forward;
            RaycastHit hitInfo;
            if (Physics.SphereCast(ray, 0.2f, out hitInfo, 50f))
            {
                lr.SetPosition(1, hitInfo.point);
                Transform parent = hitInfo.transform.parent;
                if (parent != null)
                {
              /*      Flying flyingObject = parent.GetComponent<Flying>();
                    if (flyingObject != null)
                    {
                        flyingObject.DestroyShip();
                    }*/
                }
            }
            else
                lr.SetPosition(1, playerWeapon.transform.forward * 50f);
            readyToShot = false;
            StartCoroutine(reloadCoroutine());
        }
    }

    IEnumerator reloadCoroutine()
    {
        yield return new WaitForSeconds(reload);
        readyToShot = true;
        lr.SetPosition(1, Vector3.zero);
    }

}
