using UnityEngine;

namespace Assets.Scripts
{
    public class RopeCollider : MonoBehaviour {

        void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.tag == "Bubble")
            {
                UIManager.Instance.IncreaseScore(1);

                GameObject leftBubble = Instantiate(other.gameObject, other.gameObject.transform.position, other.gameObject.transform.rotation);
                BubbleScript leftScript = leftBubble.GetComponent<BubbleScript>();
                leftScript.Init(Vector3.left);
                GameObject rightBubble = Instantiate(other.gameObject, other.gameObject.transform.position, other.gameObject.transform.rotation);
                BubbleScript rightScript = rightBubble.GetComponent<BubbleScript>();
                rightScript.Init(Vector3.right);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}
