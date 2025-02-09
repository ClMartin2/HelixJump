using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Ball ball;
	[SerializeField] private CameraFollow cameraFollow;
	[SerializeField] private float yCheckOffset = 0.5f;
	[SerializeField] private TMP_Text txtScore;
	[SerializeField] private float decreaseAddCoeef = 0.05f;
	[SerializeField] private Vector2 maxAddCoeef = new Vector2(1,1.5f);
	[SerializeField] private float startAddCoeef = 2f;


	private GameObject actualRing;
	private int currentRingIndex = 0;
	private Transform CurrentRingTranform => actualRing.transform.childCount > 0 ? 
		SpawnRings.Instance.allRings[currentRingIndex].transform.GetChild(0).transform :
		SpawnRings.Instance.allRings[currentRingIndex].transform;
	private float coeffAddScore = 1;
	private int score = 0;
	private int addScore = 1;
	private float addCoeff = 2;

	private void Start()
	{
		actualRing = SpawnRings.Instance.allRings[0];
		cameraFollow.target = CurrentRingTranform;
		cameraFollow.Init();
		ball.collide += Ball_collide;
		addCoeff = startAddCoeef;
	}

	private void Ball_collide(Ball sender)
	{
		cameraFollow.target = CurrentRingTranform;
		coeffAddScore = 1;
		addCoeff = startAddCoeef;
	}

	private void Update()
	{
		if(ball.transform.position.y < CurrentRingTranform.position.y - yCheckOffset)
		{
			PassRing();
		}
	}

	private void PassRing()
	{
		currentRingIndex++;
		actualRing = SpawnRings.Instance.allRings[currentRingIndex];
		cameraFollow.target = ball.transform;
		coeffAddScore *= addCoeff;
		addCoeff -= decreaseAddCoeef;
		addCoeff = Mathf.Clamp(addCoeff, maxAddCoeef.x, maxAddCoeef.y);
		AddScore();
	}

	private void AddScore()
	{
		score += (int)Mathf.Round(addScore * coeffAddScore);
		txtScore.text = score.ToString();
	}
}
