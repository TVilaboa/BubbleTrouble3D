using Assets.Standard_Assets.Characters.FirstPersonCharacter.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class BubbleScript : MonoBehaviour {
        public Vector3 Direction;
        private Vector3? _freezedPosition= null;
        private Vector3? _freezedVelocity = null;
        private Rigidbody _rigidbody;
        private bool _timeWasFreezed;

        private void Awake()
        {

        }

        // Use this for initialization
        void Start () {

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
        
        public void Init(Vector3 direction)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(direction * 10, ForceMode.Impulse);
        }
    }
}
