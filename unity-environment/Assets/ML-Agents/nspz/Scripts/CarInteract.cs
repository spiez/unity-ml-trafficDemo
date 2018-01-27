using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteract : MonoBehaviour
{
    public GameObject myAgent;

    public GameObject myGoalHolder;
    public GameObject myGoal;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var m_Collider = GetComponent<Collider>();

        var m_GoalCollider = myGoal.GetComponent<Collider>();

        if (m_Collider.bounds.Intersects(m_GoalCollider.bounds))
        {
            WallAgent wallAgent = myAgent.GetComponent(typeof(WallAgent)) as WallAgent;

            wallAgent.area.GetComponent<Area>().ResetArea();

            //print("collision goal <-> car!");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("collision with car!");
        if (collision.gameObject == myAgent)
        {
            Agent agent = myAgent.GetComponent<Agent>();
            agent.done = true;
            agent.reward = -1.0f;
            //print("collision agent <-> car!");
        }
       

    }

}