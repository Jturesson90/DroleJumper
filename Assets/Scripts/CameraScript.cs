using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
		public Transform followTarget;
		public float followSmothing = 1f;
		private Vector3 fixedFollowTargetPosition;
		// Use this for initialization
		void Awake ()
		{
				fixedFollowTargetPosition = transform.position;
		}

		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
			
		}
		
		void FixedUpdate ()
		{
				
				if (transform.position.y < followTarget.position.y) {
						fixedFollowTargetPosition = new Vector3 (0f, followTarget.position.y, transform.position.z);
				}
				
				transform.position = Vector3.Lerp (transform.position, fixedFollowTargetPosition, followSmothing);
		}
}
