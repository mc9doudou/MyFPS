using UnityEngine;
namespace MySample
{
    public class CollisionTest : MonoBehaviour
    {
        #region Variables
        public PlayerController player;
        #endregion

        #region Unity Event Method
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"OnCollisionEnter : {collision.transform.tag}");
            PlayerController player = collision.transform.GetComponent<PlayerController>();
            if (collision.transform.tag == "Player")
            {
                //플레이어를 왼쪽으로 3만큼 힘을 준다
                player.GoLeft();
            }
        }
        private void OnCollisionStay(Collision collision)
        {
            Debug.Log($"OnCollisionStay : {collision.transform.tag}");
        }
        private void OnCollisionExit(Collision collision)
        {
            Debug.Log($"OnCollisionExit : {collision.transform.tag}");
        }
        #endregion
    }
}