using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ring : MonoBehaviour
{
    [SerializeField] private GameObject childsContainer;
    [SerializeField] private float forceExplosion = 10f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private Transform explosionPosition;
    [SerializeField] private float durationAnimScale;
    [SerializeField] private Ease curvenAnimScale;

    private List<Transform> childsRing = new List<Transform>();

    void Start()
    {
        for (int i = 0; i < childsContainer.transform.childCount; i++)
        {
			childsRing.Add(childsContainer.transform.GetChild(i));
		}

	}
    
    public void Explode()
    {
        for(int i = 0;i < childsRing.Count; i++)
        {
            Transform actualChild = childsRing[i];
            Rigidbody actualRbChild = actualChild.GetComponent<Rigidbody>();
            MeshCollider collider = actualChild.GetComponent<MeshCollider>();

            actualRbChild.isKinematic = false;

            actualRbChild.AddExplosionForce(forceExplosion, explosionPosition.position, explosionRadius);
			actualChild.DOScale(Vector3.zero, durationAnimScale).SetEase(curvenAnimScale);
            collider.enabled = false;
		}

	}
}
