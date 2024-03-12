using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEditor.Tilemaps;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class MoveControl : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb;
    [SerializeField]
    public float DirectionX = 0;
    [SerializeField]
    public float DirectionY = 0;
    [Header("скорость игрока")]
    [Range (1,20)]public float Speed = 4;
    [HideInInspector]
    public bool isFloor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        DirectionX = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(DirectionX, 0);
        transform.Translate(movement * Speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isFloor == true)
            {
                rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                isFloor = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isFloor = true;
        }
        if (collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene(0);
        }
    }
}

