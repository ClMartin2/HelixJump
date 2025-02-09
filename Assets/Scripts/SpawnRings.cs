using System.Collections.Generic;
using UnityEngine;

public class SpawnRings : MonoBehaviour
{
    [SerializeField] private Levels level;

	public static SpawnRings Instance;
	public List<GameObject> allRings = new List<GameObject>();

	private float yPos = 0;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			Instance = this;
		}

		SpawnLevel();
	}

	private void SpawnLevel()
	{
		_SpawnRings(level.startRing, Quaternion.identity);

		for (int i = 1; i < level.nbRings; i++)
		{
			int randomIndex = Random.Range(0, level.rings.Count - 1);
			Quaternion randomRotation = Quaternion.AngleAxis(Random.Range(level.rangeRotation.x, level.rangeRotation.y), Vector3.up);

			_SpawnRings(level.rings[randomIndex], randomRotation);
		}

		GameObject LastRing = allRings[allRings.Count - 1];
		float heightLastRing = LastRing.GetComponent<MeshRenderer>().bounds.size.y;

		GameObject endRing = _SpawnRings(level.endRing, Quaternion.identity);
		float heightEndRing = endRing.GetComponent<MeshRenderer>().bounds.size.y;

		endRing.transform.position = LastRing.transform.position - Vector3.up * (heightLastRing / 2 + heightEndRing / 2);
	}

    private GameObject _SpawnRings(GameObject ring, Quaternion rotation)
    {
        Vector3 transformPosition = transform.position;

        GameObject newRing = Instantiate(ring, new Vector3(transformPosition.x, yPos, transformPosition.z), rotation, transform);
        yPos -= level.ringDistance;

		allRings.Add(newRing);

		return newRing;
	}
}
