using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Collider2D playerCollider;
    [Header("Movement information | Информация о движении")]
    public float movement;
    [Range(0.1f ,1)]public float speed = 0.2f;
    public bool staysOnGround = false;

    [Header("Moving properties | Настройки движения")]
    public float jumpForce = 10f; //На силу прыжка влияет гравитация. Чтобы сделать приятный прыжок- настраивайте оба параметра
    public KeyCode[] keyNo; //Массив из трёх элементов- движения влево, вправо и прыжка
    //Требует заполнения в редакторе!

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    ///<summary>
    /// Обычный GetAxis, только с двумя настраиваемыми кнопками и чётким разделением
    /// Если Input.GetAxis возвращает нажатые кнопки с промежутком, 
    /// то CustomAxis возвращает их без промежутка
    /// </summary> 
    
    float CustomAxis(KeyCode A, KeyCode D) {
        if (Input.GetKey(A)) return -1f;
        if (Input.GetKey(D)) return 1f;
        else return 0f;
    }

    void FixedUpdate()
    {
        movement = CustomAxis(keyNo[0], keyNo[1]);
        playerBody.position += new Vector2(movement * speed,0);

        if (Input.GetKey(keyNo[2]) && staysOnGround)
            playerBody.velocity = new Vector2(0, jumpForce);

    }

    void OnCollisionStay2D() => staysOnGround = true;
    void OnCollisionEnter2D() => staysOnGround = true;
    void OnCollisionExit2D() => staysOnGround = false;
}
