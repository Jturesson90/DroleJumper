using UnityEngine;
using System.Collections;

public class SpawnPlatforms : MonoBehaviour
{

		public GameObject[] differentPlatforms;
		private float y = 0;
		// Use this for initialization
		void Awake ()
		{
				y = transform.position.y + PlatformScript.PLATFORM_HEIGHT;
				for (int i = 0; i < 50; i++) {
						SpawnPlatform ();
				}
		}
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
				int len = GameObject.FindGameObjectsWithTag ("Bounce").Length;
				if (len < 50) {
						SpawnPlatform ();
						
				}
		}
		private void SpawnPlatform ()
		{
				float x = Camera.main.pixelWidth / 2;
				Vector3 spawnPlatformPosition = Camera.main.ScreenToWorldPoint (new Vector3 (x, y, 10));
			
				spawnPlatformPosition.y = y;
				
				GameObject newPlatform = Instantiate (differentPlatforms [0], spawnPlatformPosition, Quaternion.identity) as GameObject;
				newPlatform.transform.parent = gameObject.transform;
				
				if (ScoreManager.score < 300) {
						y += Random.Range (PlatformScript.PLATFORM_HEIGHT, (PlayerScript.JUMP_VELOCITY * PlayerScript.JUMP_VELOCITY / (2 * -Physics2D.gravity.y) * 0.1f));
				} else if (ScoreManager.score < 1000) {
						y += Random.Range (PlatformScript.PLATFORM_HEIGHT, (PlayerScript.JUMP_VELOCITY * PlayerScript.JUMP_VELOCITY / (2 * -Physics2D.gravity.y) * 0.5f));
				} else if (ScoreManager.score < 2000) {
						y += Random.Range (PlatformScript.PLATFORM_HEIGHT * 2, PlayerScript.JUMP_VELOCITY * PlayerScript.JUMP_VELOCITY / (2 * -Physics2D.gravity.y));
				} else if (ScoreManager.score < 4000) {
						y += Random.Range (PlatformScript.PLATFORM_HEIGHT * 4, PlayerScript.JUMP_VELOCITY * PlayerScript.JUMP_VELOCITY / (2 * -Physics2D.gravity.y));
				} else {
						y += PlayerScript.JUMP_VELOCITY * PlayerScript.JUMP_VELOCITY / (2 * -Physics2D.gravity.y) - 2f;
				}
		}
}
