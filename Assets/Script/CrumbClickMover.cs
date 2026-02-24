using UnityEngine;
using UnityEngine.AI;

namespace IPG.SmallWorld
{
    public class CrumbClickMover : MonoBehaviour
    {
        [Header("Click Settings")]
        [SerializeField] private Camera cam;
        [SerializeField] private LayerMask raycastMask = ~0;

        private void Reset()
        {
            cam = Camera.main;
        }

        private void Awake()
        {
            if (cam == null) cam = Camera.main;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            if (cam == null) return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit, 500f, raycastMask)) return;

            if (NavMesh.SamplePosition(hit.point, out NavMeshHit navHit, 2.0f, NavMesh.AllAreas))
            {
                transform.position = navHit.position;
            }
        }
    }
}