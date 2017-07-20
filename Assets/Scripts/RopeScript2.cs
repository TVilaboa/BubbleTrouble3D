using System.Collections;
using Assets.Standard_Assets.Characters.FirstPersonCharacter.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class RopeScript2 : MonoBehaviour {

        private bool rope;
        private LineRenderer lineRenderer;
        public Transform Roof;
        public float DestroyTimer = 1f;
        public float BetterHarponDestroyTimer = 5f;
        GameObject lineCollider;

        public float LineWidth; 

       // Use this for initialization
        void Start ()
        {
            lineRenderer = gameObject.GetComponent<LineRenderer>();
            
        }
	
        // Update is called once per frame
        void Update () {
            //if (rope && Input.GetKeyDown("d"))
            //{
            //    DestroyRope();
            //}
            if (!rope && Input.GetKeyDown("r"))
            {
                BuildRope();
            }
        }

        void BuildRope()
        {
        
            lineRenderer.enabled = true;

            lineRenderer.positionCount = 2;
            lineRenderer.widthMultiplier = 0.2f;
            var startPosition = transform.position;
            startPosition.y = 0;
            lineRenderer.SetPosition(0,startPosition);
            var targetPosition = Roof.position;
            targetPosition.x = startPosition.x;
            lineRenderer.SetPosition(1,targetPosition);

            lineCollider = new GameObject("LineCollider");

            var capsuleCollider = lineCollider.AddComponent<CapsuleCollider>();
            capsuleCollider.isTrigger = true;
            capsuleCollider.radius = LineWidth;
            capsuleCollider.center = Vector3.zero;
            capsuleCollider.direction = 2;
            capsuleCollider.transform.parent = lineRenderer.transform;
            capsuleCollider.transform.position = startPosition + (targetPosition - startPosition) / 2;
            capsuleCollider.transform.LookAt(startPosition);
            capsuleCollider.height = (targetPosition - startPosition).magnitude;

          
                lineCollider.AddComponent<RopeCollider>();
            

            rope = true;
            StartCoroutine(DestroyRope(PowerUpsManager.Instance.HasBetterHarpon ? BetterHarponDestroyTimer : DestroyTimer));
        }

    

        void DoDestroyRope()
        {
            // Stop Rendering Rope then Destroy all of its components
            rope = false;
            Destroy(lineCollider);
            lineRenderer.enabled = false;
        }

        IEnumerator DestroyRope(float time)
        {
            yield return new WaitForSeconds(time);

            DoDestroyRope();
        }
    }
}
