using UnityEngine;

namespace Assets.Scripts
{
    public class RopeCollider : MonoBehaviour {

        void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.tag == "Bubble")
            {
                UIManager.Instance.SetScore(1);
                Destroy(other.gameObject);
            }
        }
    }
}
