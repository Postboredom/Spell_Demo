using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_hit : MonoBehaviour
{
    #region Variables
    public ParticleSystem explode;
    private IEnumerator coroutine;
    #endregion

    #region Util Methods
    IEnumerator RespawnTarget(float time)
    {
        Instantiate(explode, transform);
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(time);
        GetComponent<MeshRenderer>().enabled = true;
    }
    #endregion

    #region Main Methods
    private void OnTriggerEnter(Collider other)
    {
        coroutine = RespawnTarget(2.0f);
        if (!other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        StartCoroutine(coroutine);
    }
    #endregion
}
