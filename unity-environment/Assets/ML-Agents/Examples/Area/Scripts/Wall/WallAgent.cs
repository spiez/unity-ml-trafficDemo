using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAgent : AreaAgent
{
	public GameObject goalHolder;
   // public GameObject block;
    public GameObject wall;

    private float previousStepDist = float.MaxValue;
    private Vector3 initialTransformPos;



    public override void InitializeAgent()
    {
		base.InitializeAgent();

        initialTransformPos = gameObject.transform.localPosition;


    }

    public override List<float> CollectState()
	{
		List<float> state = new List<float>();
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        state.Add((transform.position.x - area.transform.position.x));
        state.Add((transform.position.y - area.transform.position.y));
        state.Add((transform.position.z + 5 - area.transform.position.z));

        state.Add((goalHolder.transform.position.x - area.transform.position.x));
        state.Add((goalHolder.transform.position.y - area.transform.position.y));
        state.Add((goalHolder.transform.position.z + 5 - area.transform.position.z));

        //state.Add((block.transform.position.x - area.transform.position.x));
        //state.Add((block.transform.position.y - area.transform.position.y));
        //state.Add((block.transform.position.z + 5 - area.transform.position.z));

        var currentDist = Vector3.Distance(goalHolder.transform.position, gameObject.transform.position);

        state.Add(currentDist);

		state.Add(velocity.x);
		state.Add(velocity.y);
		state.Add(velocity.z);

  //      Vector3 blockVelocity = block.GetComponent<Rigidbody>().velocity;
		//state.Add(blockVelocity.x);
		//state.Add(blockVelocity.y);
		//state.Add(blockVelocity.z);

		return state;
	}

	public override void AgentStep(float[] act)
	{
        reward = -0.005f;
        MoveAgent(act);

        var currentDist = Vector3.Distance(goalHolder.transform.position, gameObject.transform.position);

        

        //print(Mathf.Abs(gameObject.transform.position.z + 5 - area.transform.position.z));

        if (gameObject.transform.position.y < 0.0f ||
            Mathf.Abs(gameObject.transform.position.x - area.transform.position.x) > 6.5f ||
            Mathf.Abs(gameObject.transform.position.z + 5 - area.transform.position.z) > 30 )
		{
			done = true;
			reward = -1f;
            //print("agent DONE!");
		}
        else if (currentDist > previousStepDist || GetComponent<Rigidbody>().velocity.sqrMagnitude < 5)
        {
            //reward = 0.006f;
            reward = -0.1f;

            //print("reward " + reward);
            //if ()
            //{
            //    reward = 0.012f;
            //}

            previousStepDist = currentDist;

        }





    }

    public override void AgentReset()
	{
        gameObject.transform.localPosition = new Vector3(Random.Range(-3.5f, 3.5f), 0f, 0f) + initialTransformPos; //@CHG MARTIN

        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

        previousStepDist = float.MaxValue;

        area.GetComponent<Area>().ResetArea();

        //print("agent RESET!" + initialTransformPos);
    }

	public override void AgentOnDone()
	{

	}
}
