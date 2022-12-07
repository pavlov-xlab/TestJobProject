using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject[] stonePrefabs;

	public void Spawn()
	{
		var position = transform.position;
		var rotation = transform.rotation;

		var index = Random.Range(0, stonePrefabs.Length);

		GameObject.Instantiate(stonePrefabs[index], position, rotation);
	}
}
