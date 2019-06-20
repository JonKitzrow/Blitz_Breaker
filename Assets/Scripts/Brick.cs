using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onChildTrigger(Collider2D other)
    {
      if (other.tag == "Ball")
      {
        StartCoroutine(breakBrick());
      }
    }

    IEnumerator breakBrick()
    {
      Destroy(GetComponent<SpriteRenderer>());
      GetComponent<ParticleSystem>().Play();
      yield return new WaitForSeconds(0.3f);
      transform.parent.GetComponent<BrickRow>().removeBrick();
      Destroy(transform.gameObject);
    }
}
