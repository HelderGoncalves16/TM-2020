using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{

    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera sceneCamara;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCamara = Camera.main;
            if (sceneCamara != null)
            {
                sceneCamara.gameObject.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        if (sceneCamara != null)
        {
            sceneCamara.gameObject.SetActive(true);
        }
    }

}
