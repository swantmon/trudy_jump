using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{
    public Transform ObjectToFollow;

    private Transform Transformation;

	// Use this for initialization
	void Start ()
    {
        Transformation = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Transformation.position = new Vector3(0, ObjectToFollow.position.y, -10);
	}
}
