using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
		Text text;
		public static int score;
		public Transform playerTransform;
		private float scoreY;
		// Use this for initialization
		void Awake ()
		{
				text = GetComponent<Text> ();
				score = 0;
				scoreY = playerTransform.transform.position.y;
		}

		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
				UpdateScore ();
				text.text = " Score: " + score;
		}

		void UpdateScore ()
		{
				if (scoreY < playerTransform.position.y * 9.5f) {
						scoreY = playerTransform.position.y * 9.5f;
							
				}
				
				score = (int)scoreY;
				
		}
}
