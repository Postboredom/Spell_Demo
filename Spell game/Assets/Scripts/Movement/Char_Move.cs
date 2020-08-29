using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Char_Move : MonoBehaviour
{
    #region Variables
    [Range(0, 10)]
    float sensitivity = 5f;
    private Vector2 currentRotation;
    public float speed = 2;
    public float jumpHeight = 10;
    private float distToGround;
    Collider col;
    #endregion

    #region Util Functions
    Vector3 GetInputTranslationDirection()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            direction += this.transform.forward;
            //direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += -this.transform.forward;

          //  direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += -this.transform.right;

          //  direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += this.transform.right;

          //  direction += Vector3.right;
        }
        if(Input.GetKey(KeyCode.Space) && OnGround())
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            direction += direction * .75f;
        }
        return direction;
    }

    bool OnGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
    #endregion

    #region Main Functions
    private void Awake()
    {
        col = this.GetComponent<Collider>();
    }
    private void Start()
    {
        distToGround = col.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {   // Exit Sample  
      /*  if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        }
        */

        // Hide and lock cursor when right mouse button pressed
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        this.transform.rotation = Quaternion.Euler(0, currentRotation.x, 0);
        this.transform.position += (speed * GetInputTranslationDirection() * Time.deltaTime);
        

    }
    #endregion
}
