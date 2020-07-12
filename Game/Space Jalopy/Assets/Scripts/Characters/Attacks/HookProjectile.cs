using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookProjectile : BaseProjectile
{
    public GameObject ropeWiggly;
    public GameObject ropeTense;
    public Vector3 startPosition;
    public float ropePartLength;
    public float startOffset;
    public PlayerShip ship;
    public List<GameObject> rope;
    public bool isHooked = false;

    public override void Init(BaseShip firingShip)
    {
        base.Init(firingShip);
        Debug.Log(transform.up);
        startPosition = transform.position;
        ropePartLength = 1;
        ship = FindObjectOfType<PlayerShip>();
        transform.up = (ship.transform.position - transform.position).normalized;
    }

    public override void Move()
    {
        if (!isHooked)
        { 
        base.Move();
        CheckIfShouldCreateMoreRopes();
        }
        else
        {
            transform.up = (ship.transform.position - transform.position).normalized;
        }
    }

    public Vector3 upWithoutZ()
    {
        return Vector3.zero;
    }

    public void CheckIfShouldCreateMoreRopes()
    {
        float distanceTravelled = Vector3.Distance(transform.position, startPosition);
        if (distanceTravelled/ropePartLength > rope.Count)
        {
            GameObject newRopePart = Instantiate(ropeWiggly,transform);
            newRopePart.transform.position = transform.position - transform.up * ropePartLength * rope.Count - transform.up * startOffset;
            rope.Add(newRopePart);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            Sprite ropeTenseSprite = ropeTense.GetComponent<SpriteRenderer>().sprite;
            foreach(GameObject part in rope)
            {
                part.GetComponent<SpriteRenderer>().sprite = ropeTenseSprite;
            }
            isHooked = true;
        }
    }
}
