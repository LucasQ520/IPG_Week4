using UnityEngine;
using UnityEngine.AI;

namespace IPG.SmallWorld
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AntFollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private NavMeshAgent agent;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (target == null) return;

            if (agent.isOnNavMesh)
            {
                agent.SetDestination(target.position);
            }
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}