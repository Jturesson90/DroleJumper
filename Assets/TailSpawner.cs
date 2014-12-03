using UnityEngine;
using System.Collections;

public class TailSpawner : MonoBehaviour
{
		public GameObject tailPrefab;
		public Transform spawnTransform;
		public float tailTimeDelay = 0.6f;
		private float tailSpawnTimer = 0f;
		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
				SpawnTail ();
		}
		private void SpawnTail ()
		{
				tailSpawnTimer += Time.deltaTime;
				if (ShouldSpawnTail ()) {
						GameObject newTail = Instantiate (tailPrefab, spawnTransform.position, Quaternion.identity) as GameObject;
						newTail.transform.parent = gameObject.transform;
						
						tailSpawnTimer = 0f;
				}
		}
		private bool ShouldSpawnTail ()
		{
				return tailSpawnTimer >= tailTimeDelay;
		}
}
