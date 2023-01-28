using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCurtain : MonoBehaviour
{
    public GameObject curtain_l;
    public GameObject curtain_r;

    RectTransform rectTrans;
    public bool isMoving = false;

    public float speed = 2;

    private void Update()
    {
      if (isMoving)
        {
            var moveSpeed = speed * Time.deltaTime;

            curtain_l.transform.position += new Vector3(moveSpeed, 0, 0);
            curtain_r.transform.position -= new Vector3(moveSpeed, 0, 0);

            Debug.Log(moveSpeed);
            if (curtain_l.transform.position.x > 1000) {
                isMoving = false;
            }
        }
    }

    public void MoveCurtaine()
    {
        isMoving = true;
    }   
}
