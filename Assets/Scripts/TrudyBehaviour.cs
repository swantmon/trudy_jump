using UnityEngine;
using System.Collections;

public class TrudyBehaviour : MonoBehaviour
{
    // Public
    public float MoveForce = 10;
    public float JumpForce = 500;

    // Private
    private Transform   Transformation;
    private Rigidbody2D Body;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Hello Trudy");

        Body = GetComponent<Rigidbody2D>();

        Transformation = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // More informations:
        // http://docs.unity3d.com/ScriptReference/Input.html

        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            Transformation.position += Vector3.left * MoveForce * Time.deltaTime;
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            Transformation.position += Vector3.right * MoveForce * Time.deltaTime;
        }

        if (Body.velocity.y < 0)
        {
            // More informations:
            // http://docs.unity3d.com/ScriptReference/LayerMask.html

            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    // Every time a collision happens this method will be called
    void OnCollisionEnter2D(Collision2D _OtherObject)
    {
        // More informations:
        // http://docs.unity3d.com/ScriptReference/Collider.OnCollisionEnter.html
        // http://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
        // http://docs.unity3d.com/ScriptReference/LayerMask.html

        Body.velocity = Vector3.zero;

        Body.AddForce(new Vector2(0.0f, JumpForce));

        gameObject.layer = LayerMask.NameToLayer("PlayerInAir");
    }

    void OnTriggerEnter2D()
    {
        Application.LoadLevel("Highscore");
    }
}
