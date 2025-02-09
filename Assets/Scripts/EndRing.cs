using UnityEngine;

public class EndRing : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		GameManager.Instance.Win();	
	}
}
