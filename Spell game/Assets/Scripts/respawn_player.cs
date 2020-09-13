using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn_player : MonoBehaviour
{
    public Transform spawn;

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
        other.transform.position = spawn.transform.position;
    }
}
