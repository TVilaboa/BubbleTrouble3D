using UnityEngine;

namespace Assets.Scripts
{
    public class RopeScript2 : MonoBehaviour {

        private bool rope;
        private LineRenderer lineRenderer;
        public Transform Roof;

        // Use this for initialization
        void Start ()
        {
            lineRenderer = gameObject.GetComponent<LineRenderer>();

        }
	
        // Update is called once per frame
        void Update () {
            if (rope && Input.GetKeyDown("d"))
            {
                DestroyRope();
            }
            if (!rope && Input.GetKeyDown("r"))
            {
                BuildRope();
            }
        }

        void BuildRope()
        {
        
            lineRenderer.enabled = true;

            lineRenderer.numPositions = 2;
            lineRenderer.SetPosition(0,transform.position);
       
            lineRenderer.SetPosition(1,Roof.position);
            rope = true;
        }

    

        void DestroyRope()
        {
            // Stop Rendering Rope then Destroy all of its components
            rope = false;
            lineRenderer.enabled = false;
        }
    }
}
