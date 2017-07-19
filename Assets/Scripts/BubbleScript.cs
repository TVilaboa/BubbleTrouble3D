using Assets.Standard_Assets.Characters.FirstPersonCharacter.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class BubbleScript : MonoBehaviour {
        public Vector3 Direction;
        public int Size;
        private Vector3? _freezedPosition= null;
        private Vector3? _freezedVelocity = null;
        private Rigidbody _rigidbody;
        private bool _timeWasFreezed;

        private void Awake()
        {

        }

        // Use this for initialization
        void Start ()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }
	
        // Update is called once per frame
        void Update () {
            if (PowerUpsManager.Instance.HasFreezeTime)
            {
                if (_freezedPosition.HasValue)
                {
                    gameObject.transform.position = _freezedPosition.Value;

                    _rigidbody.velocity = Vector3.zero;
                    _rigidbody.angularVelocity = Vector3.zero;
                }
                else
                {
                    _freezedVelocity = _rigidbody.velocity;
                    _freezedPosition = transform.position;
                }
                _timeWasFreezed = true;
            }else if (_timeWasFreezed)
            {
                _rigidbody.velocity = _freezedVelocity.Value;
                _freezedPosition = null;
                _timeWasFreezed = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
        }
        
        public void Init(Vector3 direction, int size)
        {
            Direction = direction;
            Size = size;
            _rigidbody = GetComponent<Rigidbody>();
            int force;
            gameObject.transform.localScale = new Vector3(size, size, size);
            switch (size)
            {
                //Size L
                case 3:
                    force = 15;
                    gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                //Size M
                case 2:
                    force = 20;
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
                //Size S
                case 1:
                    force = 25;
                    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                //Size XL
                default:
                    force = 10;
                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                    break;
            }

            
            _rigidbody.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}
