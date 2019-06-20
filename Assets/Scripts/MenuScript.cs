using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Rigidbody2D ball;

    void Start()
    {
      ball.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
      ball.velocity = ball.velocity * 4f / ball.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey || Input.GetMouseButtonDown(0))
        {
          SceneManager.LoadScene("SampleScene");
        }
    }
}
