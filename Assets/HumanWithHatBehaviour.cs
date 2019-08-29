using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanWithHatBehaviour : MonoBehaviour
{
	GameObject Enemy;
	Rigidbody Body;
	Ray Ray;
	// Start is called before the first frame update
	void Start()
    {
		Debug.Log(gameObject.name);
		Body = gameObject.GetComponent<Rigidbody>();
		Enemy = GameObject.FindWithTag("Enemy");
		//Rigidbody newBody = gameObject.AddComponent<Rigidbody>();
		//newBody.drag = 0.1f;
	}

    // Update is called once per frame
    void Update()
    {
		//Debug.Log($"Position: {gameObject.transform.position.y}");
		if (Body && Body.useGravity && gameObject.transform.position.y < -1)
		{
			Body.useGravity = false;
			Body.velocity = new Vector3(0, 0, 0);
			Body.drag = 0;
			Body.angularDrag = 0;
		}
	}

	private void FixedUpdate()
	{
		if (Enemy != null && Time.time > 2)
		{
			Ray = new Ray(new Vector3(Body.transform.position.x, Body.transform.position.y + 1, Body.transform.position.z), new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + 1, Enemy.transform.position.z));			
			RaycastHit hit;
			Debug.Log($"Trying to hit: {Enemy.name} at position: {Enemy.transform.position}");
			Debug.DrawLine(Body.position, Vector3.forward, Color.red, 2);
			Debug.DrawLine(Ray.origin, Ray.direction, Color.red, 1);
			if (Physics.Raycast(Ray, out hit, Mathf.Infinity))
			{
				Debug.Log($"Enemy hit! {hit.transform.name}");
				Destroy(Enemy);
				Enemy = GameObject.FindWithTag("Enemy");
			}
		}
	}
}
