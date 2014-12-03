using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
		public static float JUMP_VELOCITY = 45;
		public static float MOVE_VELOCITY = 60;

		// Use this for initialization
		
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
				CheckTrigger ();
				HandleInput ();
				HandlePlayerToBeOnScreen ();
				

		}


		private void HandlePlayerToBeOnScreen ()
		{
				Vector3 positionInScreen = Camera.main.WorldToScreenPoint (transform.position);
				if (positionInScreen.x < 0) {
						transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, positionInScreen.y, positionInScreen.z));
				} else if (positionInScreen.x > Camera.main.pixelWidth) {
						transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (0, positionInScreen.y, positionInScreen.z));
				}
				//transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		}

		private void CheckTrigger ()
		{
				
				if (rigidbody2D.velocity.y > 0) {
						collider2D.isTrigger = true;
						
				} else {
						collider2D.isTrigger = false;
				}
		}

		private void HandleInput ()
		{
				float dirX = Input.acceleration.x * MOVE_VELOCITY * Time.deltaTime;
				
				if (Input.GetKey (KeyCode.LeftArrow)) {
						dirX = -MOVE_VELOCITY * Time.deltaTime;
				}
				if (Input.GetKey (KeyCode.RightArrow)) {
						dirX = MOVE_VELOCITY * Time.deltaTime;
				}
				transform.Translate (dirX, 0, 0);
		}

		private void Jump ()
		{
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0f);
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, JUMP_VELOCITY);
				audio.Play ();
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
				print (coll.gameObject.tag);

				switch (coll.gameObject.tag) {
				case "Bounce":
						Jump ();
						break;
				default :
						break;
				}
		}
}