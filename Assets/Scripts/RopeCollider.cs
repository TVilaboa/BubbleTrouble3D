using UnityEngine;

namespace Assets.Scripts
{
    public class RopeCollider : MonoBehaviour
    {

        private AudioSource _audioSource;

        private AudioClip PlopSound { get; set; }

        public void Start()
        {
            _audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
            PlopSound = (AudioClip)Resources.Load("Sounds/Plop");
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Bubble")
            {
                _audioSource.clip = PlopSound;
                _audioSource.time = 0.5f;
                _audioSource.Play();
                UIManager.Instance.IncreaseScore(1);

                int size = other.gameObject.GetComponent<BubbleScript>().Size;
                //Duplicate Bubbles only if size is not S(1). Other sizes M(2), L(3), XL(4)
                if (size >= 2)
                {
                    GameObject leftBubble = Instantiate(other.gameObject, other.gameObject.transform.position, other.gameObject.transform.rotation);
                    BubbleScript leftScript = leftBubble.GetComponent<BubbleScript>();
                    leftScript.Init(Vector3.left, size -1);
                    GameObject rightBubble = Instantiate(other.gameObject, other.gameObject.transform.position, other.gameObject.transform.rotation);
                    BubbleScript rightScript = rightBubble.GetComponent<BubbleScript>();
                    rightScript.Init(Vector3.right, size - 1);

                }
                
                //Primero destruir la soga para evitar algun Bug
                Destroy(gameObject);
                //Ahora se destruye la burbuja padre
                Destroy(other.gameObject);
            }
        }
    }
}
