using UnityEngine;
using System.Collections;

public class BottomDestroyItems : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
			
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
			
				if (coll.gameObject.tag == "Player") {
						Time.timeScale = 0;
				} 
		}
		void OnTriggerEnter2D (Collider2D coll)
		{
				print (coll.gameObject.name);
		}

}