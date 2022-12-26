using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Spin : MonoBehaviour
{
    public Transform target;

    Vector3 Center = new Vector3(0, 0, 0);
    public float radius;
    public float offset;
    public float to_center_velocity;
    public float angle_accel;
    public float z_angle_velocity;
    float _x, _y,_z;
    float x_angle, y_angle, z_angle;


    //추후 설정한 default 값을 통해서 원하는 값을 받아오는 과정만 담으면 될 것 같음.
    // Start is called before the first frame update
    void Start()
    {
        _x = transform.position.x;
        _y = transform.position.y;
        _z = transform.position.z;

        x_angle = transform.rotation.eulerAngles.x;
        y_angle = transform.rotation.eulerAngles.y;
        z_angle = transform.rotation.eulerAngles.z;
        
        // 카메라 포지션, rotation의 초기 세팅을 그대로 가져옴.

        transform.position = new Vector3(0, _y, radius);
        transform.rotation = Quaternion.Euler(x_angle, y_angle, z_angle);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(target.position, Vector3.up, offset * Time.deltaTime);

        
        transform.rotation = Quaternion.Euler(x_angle, y_angle + 180, z_angle);
        transform.position = new Vector3(radius * Mathf.Sin(y_angle * Mathf.Deg2Rad), _y,radius * Mathf.Cos(y_angle * Mathf.Deg2Rad));

        y_angle += offset * Time.deltaTime;
        // 회전 구현

        //점차 중심에 가까워 지는 부분 구현
        if (radius > 0.4)
            radius -= Time.deltaTime * to_center_velocity;

        // 각 가속도 적용
        if (offset > 40)
            offset += Time.deltaTime * angle_accel;

        if (z_angle > 0)
            z_angle += Time.deltaTime * z_angle_velocity;
        
    }
}
