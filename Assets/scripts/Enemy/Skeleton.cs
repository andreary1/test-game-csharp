using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("Stats")]
    public float radius;
    public LayerMask layer;
    public float currentHealth;
    public Image healthBar;
    public float totalHealth;
    public bool isDead;

    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animControl;

    private Player player;
    private bool detectPlayer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && detectPlayer)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);

            if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                //chegou no limite de dist�ncia / skeleton para
                animControl.playAnim(1);
            }
            else
            {
                //skeleton segue o player
                animControl.playAnim(2);
            }

            float posX = player.transform.position.x - transform.position.x;
            if (posX > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
    }
    private void FixedUpdate()
    {
        DetectPlayer();
    }

    public void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, layer);

        if (hit != null)
        {
            //est� enxergando o player
            detectPlayer = true;
        }

        else
        {
            //n�o est� enxergando
            detectPlayer = false;
            animControl.playAnim(0);
            agent.isStopped = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
