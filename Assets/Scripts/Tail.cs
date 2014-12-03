using UnityEngine;
using System.Collections;

public class Tail : MonoBehaviour
{
		private float offsetRotation;
		private bool rotateLeft = true;
		void Awake ()
		{
				//	transform.parent = GameObject.Find ("TailParent").transform;
				offsetRotation = Random.Range (180, 360);
				float randomRotation = Random.Range (0, 100);
				if (randomRotation > 50) {
						rotateLeft = false;
				}

		}
		void Start ()
		{
				
		}
		void Update ()
		{
				if (rotateLeft) {
						transform.Rotate (Vector3.forward * Time.deltaTime * offsetRotation);
				} else {
						transform.Rotate (Vector3.forward * Time.deltaTime * -offsetRotation);
				}
				
		}
		void KillTail ()
		{
				Destroy (gameObject, 0f);
		}
}
