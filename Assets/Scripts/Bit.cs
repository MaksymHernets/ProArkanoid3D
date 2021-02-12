using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bit : MonoBehaviour
{
	public delegate void Hit();
	public event Hit EventHit;

	private bool key = true;

	private void OnTriggerEnter(Collider other)
	{
		if ( other.gameObject.name == "Ball" && key)
		{
			key = false;
			EventHit();
			var rigidbod = other.gameObject.GetComponent<Rigidbody>();
			rigidbod.isKinematic = true;
			rigidbod.isKinematic = false;
			rigidbod.AddForce(new Vector3(transform.localPosition.x*100f, 0f, 100f));
			StartCoroutine(Wait());
		}
	}

	// Этот костыль надо, чтобы триггер срабатывал один раз, а не 2 -3 раза
	IEnumerator	Wait()
	{
		yield return new WaitForSeconds(0.5f);
		key = true;
	}


}
