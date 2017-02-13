﻿using UnityEngine;
using System.Collections;

public class SpawnCactus : MonoBehaviour {

	
	public Transform[] CactusPrefabs;
	public Vector2 Time2Spawn;
	
	public Score score;
	public PlayPause ppause;
	public DinoController Dino;
	public Transform Point2Destroy;
	
	private float LastTime = 0;

	void Update () {
		float ActualTime = Time.time;
		if (!ppause.Pause) {
			if (ActualTime > LastTime) {
				float RandTime = Random.Range (Time2Spawn.x, Time2Spawn.y);
				LastTime += RandTime;
				CreateCactus();
			}
		} else {
			LastTime = Time.time;
		}
	}

	void CreateCactus () {
		int RandCactus = (int) Random.Range(0,6);
		Transform Cactus = CactusPrefabs[RandCactus];
		
		Transform tClactus = Instantiate(Cactus, transform.position, transform.rotation) as Transform;
		CactusController tcCactus = tClactus.GetComponent<CactusController>();
		
		tcCactus.Dino = Dino;
		tcCactus.Point2Destroy = Point2Destroy;
		tcCactus.score = score;
		tcCactus.ppause = ppause;
	}
}
