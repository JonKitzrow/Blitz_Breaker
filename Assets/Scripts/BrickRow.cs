using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickRow : MonoBehaviour
{
    bool madeNextRow = false;
    public Transform rowPrefab;
    GameController gc;
    public float brickDescentSpeed;
    int bricksLeft = 11;

    // Start is called before the first frame update
    void Start()
    {
      gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
      // update bricks
      transform.position += Vector3.down * Time.deltaTime * brickDescentSpeed;

      if (!madeNextRow && transform.position.y <= 5.2f)
      {
        Instantiate(rowPrefab, new Vector3(0, 6f, 0), Quaternion.identity);
        madeNextRow = true;
      }

      if (bricksLeft <= 0)
      {
        Destroy(transform.gameObject);
      }

      if (transform.position.y <= -4.8f)
      {
        gc.gameOver();
      }
    }

    public void removeBrick()
    {
      bricksLeft--;
      gc.addScore(1);
    }
}
