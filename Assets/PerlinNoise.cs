using UnityEngine;
using System.Collections;

public class PerlinNoise : MonoBehaviour
{
		public float xOrg;
		public float yOrg;
		public float scale = 1.0F;
		private int width;
		private int height;
		private Color[] pix;
		void Start ()
		{
				width = (int)(renderer.bounds.size.x * 100);
				height = (int)(renderer.bounds.size.y * 100);
				
				pix = new Color[width * height];
				print (pix.Length);
				//renderer.material.color = pix;
		}
		void CalcNoise ()
		{
				int y = 0;
				while (y < height) {
						int x = 0;
						while (x < width) {
								float xCoord = xOrg + x / width * scale;
								float yCoord = yOrg + y / height * scale;
								float sample = Mathf.PerlinNoise (xCoord, yCoord);
								Color c = new Color (sample, sample, sample);
								//print (y * height + x);
								pix [y * height + x] = c;
								x++;
						}
						y++;
				}
				//renderer.material.se
				
		}
		void Update ()
		{
				CalcNoise ();
		}
}