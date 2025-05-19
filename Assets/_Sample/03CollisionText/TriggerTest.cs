using UnityEngine;
namespace MySample
{
    public class TriggerTest : MonoBehaviour
    {
        #region Variables
        public PlayerController player;
        #endregion

        #region Unity Event Method
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"OnTriggerEnter : {other.transform.tag}");
            PlayerController player = other.transform.GetComponent<PlayerController>();
            if (other.transform.tag == "Player")
            {
                //플레이어를 왼쪽으로 3만큼 힘을 준다
                player.GoRight();
            }
        }
        private void OnTriggerStay(Collider other)
        {
            Debug.Log($"OnTriggerStay : {other.transform.tag}");

        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log($"OnTriggerExit : {other.transform.tag}");
            player.GoRight();
        }

        #endregion
    }
}