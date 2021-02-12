using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Bit bit;
    public Ball ball;
    public ControlBall controlBall;
	public GameObject spawnBall;

    public Counter counterBit;
    public Counter counterGoal;
	
	private bool IsStart = false;

	private void Start()
	{
		bit.EventHit += Bit_EventHit;
		controlBall.EventMove += ControlBall_EventMove;
    }

	private void ControlBall_EventMove(float x)
	{
		bit.transform.localPosition = new Vector3(x , bit.transform.localPosition.y , bit.transform.localPosition.z);
	}

	private void Bit_EventHit()
	{
        counterBit.Increment();
    }

	void Update()
    {
        if ( IsStart == false && Input.GetKeyDown(KeyCode.Mouse0) )
		{
			IsStart = true;
			ball.rigidb.AddForce(new Vector3(Random.Range(-60, 60) , 0f , -40f));
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
		if ( collision.gameObject.name == "Ball")
		{
			ball.transform.localPosition = spawnBall.transform.position;
			ball.rigidb.isKinematic = true;
			ball.rigidb.isKinematic = false;
			IsStart = false;
			counterGoal.Increment();
			counterBit.Resett();
		}
	}
}
