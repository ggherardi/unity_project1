using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HumanWithHatBehaviour : MonoBehaviour
{
	GameObject Enemy;
	GameObject Body;
    Rigidbody RigidbodyComponent;
    Ray Ray;
    private List<PlayerAction> PlayerActions;
    private readonly Func<PlayerAction, bool> VerifyInput = (p) => { return Input.GetKey(p.AssignedKey); };
    LayerMask FloorMask;

    // Start is called before the first frame update
    void Start()
    {
        RigidbodyComponent = gameObject.GetComponent<Rigidbody>();
        Body = gameObject.transform.Find("Body")?.gameObject;
		Enemy = GameObject.FindWithTag("Enemy");
        PlayerActions = new List<PlayerAction>()
        {
            new PlayerAction("MoveForward", KeyCode.UpArrow, MovingUp),
            new PlayerAction("MouseClick", KeyCode.Mouse0, MouseClick)
        };
        FloorMask = LayerMask.GetMask("Floor");
        //Rigidbody newBody = gameObject.AddComponent<Rigidbody>();
        //newBody.drag = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        IEnumerable<PlayerAction> inputtedPlayerActions = PlayerActions.Where(VerifyInput);
        foreach (PlayerAction inputtedPlayerAction in inputtedPlayerActions)
        {
            inputtedPlayerAction.Action();
        }
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
  //      if (!Enemy)
		//{
		//	Enemy = GameObject.FindWithTag("Enemy");
		//}		
		//if (Enemy != null)
		//{
		//	Ray = new Ray(Body.transform.position, Vector3.forward);			
		//	RaycastHit hit;			
		//	Debug.DrawRay(Ray.origin, Ray.direction, Color.red, 1);
		//	if (Physics.Raycast(Ray, out hit, Mathf.Infinity))
		//	{
		//		Debug.Log($"Enemy hit! {hit.collider.name}");
		//		GameObject hitRender = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//		hitRender.transform.position = hit.transform.position;
		//		Destroy(Enemy);				
		//	}
		//}
	}

    public void MovingUp()
    {
        int speed = 10;
        RigidbodyComponent.AddForce(Vector3.forward * speed, ForceMode.Force);
        Debug.Log("Moving up!");
    }
    public void MouseClick()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit mouseHit, Mathf.Infinity, FloorMask))
        {
            Debug.Log($"Mouse hit {mouseHit.transform.name} with layer {mouseHit.transform.gameObject.layer}");
        }
    }
}

public class PlayerAction
{
    public string Name { get; set; }
    public KeyCode AssignedKey { get; set; }
    public Action Action { get; set; }
    public PlayerAction(string name, KeyCode assignedKey, Action action)
    {
        this.Name = name;
        this.AssignedKey = assignedKey;
        this.Action = action;
    }
}

