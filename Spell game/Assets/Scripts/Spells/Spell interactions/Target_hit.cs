using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_hit : MonoBehaviour
{
    #region Variables
    public ParticleSystem explode;
    private IEnumerator coroutine;
    public float power;
    public float range;
    #endregion

    #region Util Methods
    IEnumerator RespawnTarget(float time, Rigidbody other)
    {
        Instantiate(explode, transform);
        other.AddExplosionForce(power, transform.position, range);
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(time);
        GetComponent<MeshRenderer>().enabled = true;
    }
    #endregion

    #region Main Methods
    private void OnTriggerEnter(Collider other)
    {
        coroutine = RespawnTarget(2.0f, other.GetComponent<Rigidbody>());
        if (!other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
        StartCoroutine(coroutine);
    }
    #endregion
}
