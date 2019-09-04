using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanWithHatBehaviour : MonoBehaviour
{
	GameObject Enemy;
	GameObject Body;
	Ray Ray;
	// Start is called before the first frame update
	void Start()
    {
		Debug.Log(gameObject.name);
		Body = gameObject.transform.Find("Body")?.gameObject;
		Enemy = GameObject.FindWithTag("Enemy");
		//Rigidbody newBody = gameObject.AddComponent<Rigidbody>();
		//newBody.drag = 0.1f;
	}

    // Update is called once per frame
    void Update()
    {
		//Debug.Log($"Position: {gameObject.transform.position.y}");
		//if (Body && Body.useGravity && gameObject.transform.position.y < -1)
		//{
		//	Body.useGravity = false;
		//	Body.velocity = new Vector3(0, 0, 0);
		//	Body.drag = 0;
		//	Body.angularDrag = 0;
		//}
	}

	private void FixedUpdate()
	{
		if (!Enemy)
		{
			Enemy = GameObject.FindWithTag("Enemy");
		}		
		if (Enemy != null)
		{
			Ray = new Ray(Body.transform.position, Vector3.forward);			
			RaycastHit hit;
			//Debug.Log($"Trying to hit: {Enemy.name} at position: {Enemy.transform.position}");
			Debug.DrawRay(Ray.origin, Ray.direction, Color.red, 1);
			if (Physics.Raycast(Ray, out hit, Mathf.Infinity))
			{
				Debug.Log($"Enemy hit! {hit.collider.name}");
				GameObject hitRender = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				hitRender.transform.position = hit.transform.position;
				Destroy(Enemy);				
			}
		}
	}
}
