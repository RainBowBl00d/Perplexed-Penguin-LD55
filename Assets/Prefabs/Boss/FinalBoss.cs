using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public Health health;

    // Phase transition thresholds
    public int phase1Threshold = 300;

    // Boss phases
    public enum BossPhase { Phase1,  FinalPhase }
    public BossPhase currentPhase;

    // References to other components
    private Animator bossAnimator;
    private Transform player;
    private bool isInvulnerable = false;

    // Phase 1 variables
    public float bossSpeed = 5f; // Boss movement speed
    public float attackRange = 3f; // Range at which boss attacks
    public int punchDamage = 20; // Damage dealt by boss punch

    public int numClones = 20;
    public float circleRadius = 10f;
    public GameObject clonePrefab;

    public bool isOriginalBoss = true; 

    void Start()
    {
        health.health = health.maxHealth;
        bossAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateHealthBar();
        currentPhase = BossPhase.Phase1;
    }

    void Update()
    {
        UpdateHealthBar();
        switch (currentPhase)
        {
            case BossPhase.Phase1:
                Phase1Behavior();
                break;
            case BossPhase.FinalPhase:
                FinalPhaseBehavior();
                break;
        }
    }

    void Phase1Behavior()
    {

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * bossSpeed * Time.deltaTime;

        if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < attackRange)
        {
            bossAnimator.SetTrigger("Punch");
            PlayerStats.instance.health.SubtractHealt(punchDamage);
        }
    }

    void FinalPhaseBehavior()
    {

        if (isOriginalBoss)
        {
            Vector3 playerPosition = player.position;
            for (int i = 0; i < numClones; i++)
            {
                float angle = i * Mathf.PI * 2f / numClones;
                Vector3 circlePosition = playerPosition + new Vector3(Mathf.Cos(angle) * circleRadius, Mathf.Sin(angle) * circleRadius, 0f);

                Instantiate(clonePrefab, circlePosition, Quaternion.identity);
            }
        }

    }

    void UpdateHealthBar()
    {
        float healthPercentage = (float)health.health / health.maxHealth;
    }
}
