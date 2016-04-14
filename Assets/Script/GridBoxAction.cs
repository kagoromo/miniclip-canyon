﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridBoxAction : MonoBehaviour {

	public bool isPressable;
	public GameObject currentMap;
	public GameManagerBehavior gameManager;
	public GameObject[] towerPrefabs;

	Vector3 mouseDownMapTransform;

	void OnMouseDown() {
		mouseDownMapTransform = currentMap.transform.position;
	}

	void OnMouseUpAsButton() {
		// Action goes here
		if (GameManagerBehavior.whatTowerIsPressed != -1)
		{
			print("build tower " + GameManagerBehavior.whatTowerIsPressed);
			if (mouseDownMapTransform == currentMap.transform.position)
			{
				if (CanBuildTower())
				{
					GameObject tower = (GameObject)Instantiate(towerPrefabs[GameManagerBehavior.whatTowerIsPressed], transform.position, Quaternion.identity);
					gameManager.Gold -= tower.GetComponent<TowerData>().cost;
					isPressable = false;
				}
			}
		}
	}

	bool CanBuildTower() {
		print("checking can build");
		GameObject towerPrefab = towerPrefabs[GameManagerBehavior.whatTowerIsPressed];
		int cost = towerPrefab.GetComponent<TowerData>().cost;
		return isPressable && (gameManager.Gold >= cost);
	}
}
