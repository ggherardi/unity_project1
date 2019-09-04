﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public GameObject NewHumanWithHat;
	private List<PlayerAction> PlayerActions;
	private readonly Func<PlayerAction, bool> VerifyInput = (p) => { return Input.GetKey(p.AssignedKey); };

    // Start is called before the first frame update
    void Start()
    {
		PlayerActions = new List<PlayerAction>()
		{
			new PlayerAction("MoveForward", KeyCode.UpArrow, MovingUp),
			new PlayerAction("MouseClick", KeyCode.Mouse0, MouseClick)
		};
	}

    // Update is called once per frame
    void Update()
    {
		int enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
		if (Time.time > 5 && enemiesCount < 1)
		{
			//var newPrefab = Instantiate(NewHumanWithHat);
			GameObject prefab = Resources.Load(@"Prefabs/Human") as GameObject;
			Instantiate(prefab);
		}

		IEnumerable<PlayerAction> inputtedPlayerActions = PlayerActions.Where(VerifyInput);
		foreach (PlayerAction inputtedPlayerAction in inputtedPlayerActions)
		{
			inputtedPlayerAction.Action();
		}
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(mouseRay))
		{
			Debug.Log("Mouse hit something!");
		}
	}

	void MovingUp() { Debug.Log("Moving up!"); }
	void MouseClick() { Debug.Log("Click!"); }
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
