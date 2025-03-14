using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float TimeMove;

    private float TimeCount;

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;

        if(TimeCount < TimeMove)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerItems>().totalWood++;
            Destroy(gameObject);
        }
    }
}
