using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public float minMoveSpeed = 0;
    public float maxMoveSpeed = 0;
    private float moveSpeed;
    public float innerRadius = 1;
    public float outerRadius = 5;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        AgentController[] agents = (AgentController[])GameObject.FindObjectsOfType(typeof(AgentController));

        Vector2 force = Vector2.zero;

        foreach (AgentController agent in agents)
        {
            if (agent != this)
            {
                float distance = Vector2.Distance(agent.transform.position, transform.position);
                Vector2 direction = ((Vector2)(agent.transform.position - transform.position)).normalized;

                if (distance >= outerRadius)
                {
                    force += direction * outerRadius / distance;
                    // rb.AddForce(direction * moveSpeed * outerRadius / distance);
                }
                else if (distance <= innerRadius)
                {
                    force -= direction;
                    rb.AddForce(direction * -moveSpeed * 10);
                }
            }
        }

        rb.AddForce(force.normalized * moveSpeed);

        GameObject player = GameObject.FindWithTag("Player");
        float playerDistance = Vector2.Distance(player.transform.position, transform.position);

        float alpha = 1f;
        if (playerDistance <= innerRadius)
        {
            alpha = 0.5f;
        }

        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
    }
}
