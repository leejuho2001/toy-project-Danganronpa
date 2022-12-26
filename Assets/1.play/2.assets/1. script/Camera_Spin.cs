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


    //���� ������ default ���� ���ؼ� ���ϴ� ���� �޾ƿ��� ������ ������ �� �� ����.
    // Start is called before the first frame update
    void Start()
    {
        _x = transform.position.x;
        _y = transform.position.y;
        _z = transform.position.z;

        x_angle = transform.rotation.eulerAngles.x;
        y_angle = transform.rotation.eulerAngles.y;
        z_angle = transform.rotation.eulerAngles.z;
        
        // ī�޶� ������, rotation�� �ʱ� ������ �״�� ������.

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
        // ȸ�� ����

        //���� �߽ɿ� ����� ���� �κ� ����
        if (radius > 0.4)
            radius -= Time.deltaTime * to_center_velocity;

        // �� ���ӵ� ����
        if (offset > 40)
            offset += Time.deltaTime * angle_accel;

        if (z_angle > 0)
            z_angle += Time.deltaTime * z_angle_velocity;
        
    }
}
