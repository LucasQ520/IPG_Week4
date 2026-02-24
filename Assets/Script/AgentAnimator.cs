using UnityEngine;
using UnityEngine.AI;

namespace IPG.SmallWorld
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class AgentAnimatorBridge : MonoBehaviour
    {
        [SerializeField] private string speedParam = "Speed";
        [SerializeField] private float dampTime = 0.1f;

        private NavMeshAgent agent;
        private Animator animator;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            float speed = agent.velocity.magnitude;
            animator.SetFloat(speedParam, speed, dampTime, Time.deltaTime);
        }
    }
}