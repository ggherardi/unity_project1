using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public GameObject NewHumanWithHat;

    // Start is called before the first frame update
    void Start()
    {

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
	}
}