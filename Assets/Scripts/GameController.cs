using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform ball, paddleParent;
    int score = 0;
    float paddleRotation, screenToWorld;
    public float paddleRotationSpeed = 10;
    public float paddleRotationThreshold = 16;
    public float ballSpeed = 3f;
    public Canvas gameOverUI, gameRunningUI;
    public Text scoreText, gameOverScore;

    // Start is called before the first frame update
    void Start()
    {
      screenToWorld = 17.8f / Screen.width; // conversion factor to go from screen to world coordinates
      ball.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(0, 1f), 0) * ballSpeed;
      gameRunningUI.enabled = true;
      gameOverUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      // update paddle
      if (Mathf.Abs(Input.mousePosition.x) <= Screen.width)
      {
        paddleParent.position = new Vector3(Input.mousePosition.x * screenToWorld - Screen.width * screenToWorld * 0.5f, paddleParent.position.y, 0);
      }

      if (Input.GetKey("a") && !Input.GetKey("d") && paddleRotation < paddleRotationThreshold)
      {
          paddleRotation += paddleRotationSpeed * Time.deltaTime;
          if (paddleRotation > paddleRotationThreshold)
          {
            paddleRotation = paddleRotationThreshold;
          }
      }
      else if (Input.GetKey("d") && !Input.GetKey("a") && paddleRotation > -paddleRotationThreshold)
      {
          paddleRotation -= paddleRotationSpeed * Time.deltaTime;
          if (paddleRotation < -paddleRotationThreshold)
          {
            paddleRotation = -paddleRotationThreshold;
          }
      }
      else if (!Input.GetKey("a") && !Input.GetKey("d"))
      {
        if (paddleRotation > 0)
        {
          paddleRotation -= paddleRotationSpeed * Time.deltaTime;
          if (paddleRotation < 0)
          {
            paddleRotation = 0;
          }
        }
        if (paddleRotation < 0)
        {
          paddleRotation += paddleRotationSpeed * Time.deltaTime;
          if (paddleRotation > 0)
          {
            paddleRotation = 0;
          }
        }
      }

      paddleParent.eulerAngles = Vector3.forward * paddleRotation;

      // check whether ball is out of bounds
      if (ball.position.y < -6f)
      {
        Destroy(ball.gameObject);
        gameOver();
      }

      if (ball.GetComponent<Rigidbody2D>().velocity.magnitude != ballSpeed)
      {
        ball.GetComponent<Rigidbody2D>().velocity = ball.GetComponent<Rigidbody2D>().velocity * ballSpeed / ball.GetComponent<Rigidbody2D>().velocity.magnitude;
      }

      scoreText.text = score.ToString();
    }

    public void gameOver()
    {
      gameOverScore.text = score.ToString();
      gameRunningUI.enabled = false;
      gameOverUI.enabled = true;
      // StartCoroutine(nextSceneOnClick());
    }

    public void addScore(int addThis)
    {
      score += addThis;
    }

    IEnumerator nextSceneOnClick()
    {
      while (Input.anyKey)
      {
        yield return null;
      }
      while (!Input.anyKey && !Input.GetMouseButtonDown(0))
      {
        yield return null;
      }
      SceneManager.LoadScene("Menu");
    }
}
