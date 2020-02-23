using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    private Vector3 target; //Нужен для хранения модифицированного вектора позиции цели
    private float cameraZ = -10;
    
    [Header("Properties | Настройки")]
    public float delta = 0.85f;
    public bool useY=true;

    [Header("Target | Цель")]
    public Transform targetTransform; //Заполнить в редакторе!

    void Start()
    {
        //Модифицируем z координату
        target.z = transform.position.z;
    }

    void FixedUpdate()
    {
        target.x = targetTransform.position.x;
        if(useY) target.y = targetTransform.position.y;

        //Передвижение
        transform.position = Vector3.Lerp(target, transform.position, delta);
    }
}
