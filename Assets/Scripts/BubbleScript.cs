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


        // Use this for initialization
        void Start () {
            Direction = Vector3.left;
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(Direction * 10 , ForceMode.Impulse);
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
            if (collision.gameObject.name == "Player") {
                GameObject aux = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                aux.GetComponent<BubbleScript>().Direction = Vector3.right;
                Destroy(gameObject);
            }
        
        
        }

        //Spawn two children of less size
        private void spawnChildren() {

        }
    }
}
