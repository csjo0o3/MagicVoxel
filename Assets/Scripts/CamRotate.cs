using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    //현재 각도
    Vector3 angle;
    //마우스 감도 퍼블릭으로 하면 외부에서 설정이 가능하게 됨.
    public float sensitivity = 200;
    // Start is called before the first frame update
    void Start()
    {
        angle = Camera.main.transform.eulerAngles;
        //카메라가 보고있는게 반대로 들어가야한다
        angle.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");
        angle.x += x * sensitivity * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;

        angle.x = Mathf.Clamp(angle.x, -90, 90);
        transform.eulerAngles = new Vector3(-angle.x, angle.y, transform.eulerAngles.z);
    }
}
