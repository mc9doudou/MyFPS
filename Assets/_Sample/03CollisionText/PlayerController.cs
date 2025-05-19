using UnityEngine;
using UnityEngine.InputSystem;

namespace MySample 
{ 
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        //참조
        private Rigidbody rb;
       
        //오브젝트에 주는 힘 
        [SerializeField] private float movePower = 3f;
        #endregion
        #region Unity Event Method
        private void Start()
        {
            //참조
            rb = this.GetComponent<Rigidbody>();


            //시작할때 오른쪽 힘 준다: 3f - 일회성
            GoRight();
        }
        #endregion
        #region Custom Method
        //플레이어를 왼쪽으로 3만큼 힘을 준다
        public void GoRight()
        {
            rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);
        }
        public void GoLeft()
        {
            rb.AddForce(Vector3.left * movePower, ForceMode.Impulse);
        }
        #endregion
    }
}