using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Flight : MonoBehaviour
{
    #region Variables
    private Vector3 fwd;
    private float speed;
    #endregion

    private void Start()
    {
        fwd = transform.forward;
        speed = Random.Range(1, 10);
    }
    void Update()
    {
        transform.position += fwd * (Time.deltaTime * speed );
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        Destroy(gameObject);
    }
}
