using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoariDestroy : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		// Õ“Ë‚µ‚½‘Šè‚ÉPlayerƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
		if (collision.gameObject.tag == "Yokoari")
		{
			// “–‚½‚Á‚½‘Šè‚ğ1•bŒã‚Éíœ
			Destroy(collision.gameObject);
		}
	}
}
