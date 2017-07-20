using UnityEngine;

namespace Assets.Scripts
{
    public class PowerUp : MonoBehaviour {

        void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {
                switch (gameObject.tag)
                {
                    case "FreezeTimePowerUp":
                        PowerUpsManager.Instance.HasFreezeTime = true;
                        break;
                    case "CanRunPowerUp":
                        PowerUpsManager.Instance.CanRun = true;
                        break;
                    case "InmunityPowerUp":
                        PowerUpsManager.Instance.HasInmunity = true;
                        break;
                    case "BetterHarponPowerUp":
                        PowerUpsManager.Instance.HasBetterHarpon = true;
                        break;

                }
                Destroy(gameObject);
            }
        }
    }
}
