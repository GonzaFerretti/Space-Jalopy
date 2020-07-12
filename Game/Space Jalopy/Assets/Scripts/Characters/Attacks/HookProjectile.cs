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
    public Vector2 hookOffset;
    public PlayerShip ship;
    public List<GameObject> rope;
    public bool isHooked = false;
    public float speedPenalty;
    public BaseShip _firingShip;
    public float minSpeedPenalty;
    public float TimeRemaining;

    public override void Init(BaseShip firingShip)
    {
        base.Init(firingShip);
        _firingShip = firingShip;
        Debug.Log(transform.up);
        startPosition = new Vector3(transform.position.x,transform.position.y,0);
        ropePartLength = 1;
        ship = FindObjectOfType<PlayerShip>();
        transform.up = (ship.transform.position - startPosition).normalized;
    }

    public override void Move()
    {
        if (!isHooked)
        { 
            base.Move();
            CheckIfShouldCreateMoreRopes(startPosition);
        }
        else
        {
            TimeRemaining -= Time.deltaTime;
            if (TimeRemaining <= 0)
            {
                ship.baseMoveSpeed = Mathf.Clamp(ship.baseMoveSpeed + speedPenalty, minSpeedPenalty * ship.originalSpeed, ship.originalSpeed);
                Destroy(gameObject);
            }
            CheckIfShouldCreateMoreRopes(_firingShip.attackSpawnPoint.transform.position);
            transform.position = ship.transform.position - (Vector3)hookOffset;
            transform.up = (ship.transform.position - new Vector3(_firingShip.attackSpawnPoint.transform.position.x, _firingShip.attackSpawnPoint.transform.position.y, 0)).normalized;
        }
    }

    public void CheckIfShouldCreateMoreRopes(Vector3 referencePoint)
    {
        float distanceTravelled = Vector3.Distance(transform.position, referencePoint);
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
            hookOffset = ship.transform.position - transform.position;
            ship.baseMoveSpeed = Mathf.Clamp(ship.baseMoveSpeed - speedPenalty, minSpeedPenalty * ship.originalSpeed, float.MaxValue); 
        }
    }
}
