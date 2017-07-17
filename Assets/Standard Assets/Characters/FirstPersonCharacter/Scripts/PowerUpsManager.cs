using System.Collections;
using UnityEngine;

namespace Assets.Standard_Assets.Characters.FirstPersonCharacter.Scripts
{
    public class PowerUpsManager : MonoBehaviour
    {
        public GameObject[] PowerUps = new GameObject[4];
        //public GameObject BetterHarponPowerUp;
        //public GameObject InmunityPowerUp;
        //public GameObject FreezeTimePowerUp;
        public Transform Floor;
        public bool HasBetterHarpon;
        public bool HasInmunity;

        public bool CanRun
        {
            get { return _canRun; }
            set
            {
                _canRun = value;
                if (_canRun)
                {
                    StartCoroutine(CancelCanRun(RunDuration));
                }
            }
        }

        private bool _hasFreezeTime;
        public float FreezeTimeDuration = 20f;
        public float RunDuration = 20f;
        private bool _canRun;

        public bool HasFreezeTime
        {
            get { return _hasFreezeTime; }
            set
            {
                _hasFreezeTime = value;
                if (_hasFreezeTime)
                {
                    StartCoroutine(UnfreezeTime(FreezeTimeDuration));
                }
            } 
        }

        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }

        }

        //singleton implementation
        private static PowerUpsManager instance;
        public static PowerUpsManager Instance
        {
            get { return instance ?? (instance = new PowerUpsManager()); }
        }

        // Update is called once per frame
        void Update ()
        {
            SpawnPowerUps();
        }

        private void SpawnPowerUps()
        {
            if (Random.Range(0, 9) >= 0.001)
            {
                var powerUp = PowerUps[Random.Range(0, 3)];
                var position = Floor.position;
                position.x = Random.Range(-29, 29);
                Instantiate(powerUp,position,Quaternion.identity);
            }
        }

        IEnumerator UnfreezeTime(float time)
        {
            yield return new WaitForSeconds(time);

            HasFreezeTime = false;
        }

        IEnumerator CancelCanRun(float time)
        {
            yield return new WaitForSeconds(time);

            CanRun = false;
        }
    }
}
