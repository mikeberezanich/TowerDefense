using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        public float firstTurnPoint = -6; //location of first turn
        public float movementSpeed = 10;
        public Vector3 destination;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            destination = agent.destination;

            agent.updateRotation = false;
	        agent.updatePosition = true;

            
        }


        private void Update()
        {
            //if (target != null)
            //agent.SetDestination(firstSegment);

            //if (agent.remainingDistance > agent.stoppingDistance)
            //    character.Move(agent.desiredVelocity, false, false);
            //else
            //    character.Move(Vector3.zero, false, false);

            //if (transform.position.z < firstTurnPoint)
            //{
            //    transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

            //}

            // Update destination if the target moves one unit
            if (Vector3.Distance(destination, target.position) > 1.0f)
            {
                destination = target.position;
                agent.destination = destination;
            }

        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
