using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour
{
		bool seen;
		bool isAMovingPlatform = false;
		public float platformSpeed = 5f;
		private float leftEdge, rightEdge;
		public bool firstPlatform = false;
		public static float PLATFORM_HEIGHT = 25;
		//SpriteRenderer spriteRendererInChild;
		
		float halfWidth;
		// Use this for initialization
		void Awake ()
		{
				
				PlatformScript.PLATFORM_HEIGHT = (float)transform.GetChild (0).renderer.bounds.size.y;
			
				leftEdge = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0)).x;
				rightEdge = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0)).x;
				seen = false;
				halfWidth = (float)transform.GetChild (0).renderer.bounds.size.x * 0.5f;	
//				spriteRendererInChild = gameObject.GetComponentInChildren<SpriteRenderer> ();
		}

		void Start ()
		{
				if (!firstPlatform) {
						if (ScoreManager.score > 1500) {
								isAMovingPlatform = Random.Range (0f, 1f) > 0.5f ? true : false;
						}	
						transform.position = new Vector3 (Random.Range (leftEdge + halfWidth, rightEdge - halfWidth), transform.position.y, transform.position.z);
				}
				
		}
		void FixedUpdate ()
		{
				
				
				
				//	spriteRendererInChild.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		}
		// Update is called once per frame
		void Update ()
		{
				
				if (gameObject.GetComponentInChildren<Renderer> ().isVisible) {
						seen = true;
				}
				if (seen && !gameObject.GetComponentInChildren<Renderer> ().isVisible) {
						Destroy (gameObject);
				}
				
				if (isAMovingPlatform) {
						if (transform.position.x - halfWidth < leftEdge && platformSpeed < 0) {
								platformSpeed = -platformSpeed;
						} else if (transform.position.x + halfWidth > rightEdge && platformSpeed > 0) {
								platformSpeed = -platformSpeed;
						}
						transform.Translate (new Vector3 (platformSpeed * Time.deltaTime, 0, 0));
				}
		}
}
