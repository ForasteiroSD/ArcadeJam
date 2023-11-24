using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BuffSelector : MonoBehaviour
{
    [SerializeField] bool Player1;
    [SerializeField] BoxCollider2D  _colliderPlayer;
    [SerializeField] float buffActivationInterval = 10f; // Time interval for activating buffs
    [SerializeField] Sprite _adrenaline; // Buff 1
    [SerializeField] Sprite _boot; //Buff 2
    [SerializeField] Sprite _baseballBat; //Buff 3
    [SerializeField] Sprite _taser; // Buff 4
    [SerializeField] Sprite none;
    
    [SerializeField] SpriteRenderer spriteRenderer1; 
    [SerializeField] SpriteRenderer spriteRenderer2;
    private float nextBuffActivationTime;
    private int randomBuff1, randomBuff2;

    private Adrenaline adrenalinaInstance;
    private BaseballBat baseballBatInstance;
    private TaserCollider taserColliderInstance;
    private DoubleJump doubleJumpInstance;

    void Start()
    {
        // Set the initial buff activation time
        nextBuffActivationTime = Time.time + buffActivationInterval;
        adrenalinaInstance = GetComponent<Adrenaline>();
        baseballBatInstance = GetComponent<BaseballBat>();
        taserColliderInstance = GetComponent<TaserCollider>();
        doubleJumpInstance = GetComponent<DoubleJump>();
    }

    void Update()
    {
        // Check if it's time to activate buffs
        if (Time.time >= nextBuffActivationTime)
        {
            ActivateRandomBuffs();
            // Set the next buff activation time
            nextBuffActivationTime = Time.time + buffActivationInterval;
        }
        if (Player1)
        {    // Check for player input to select buffs
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SelectBuff(randomBuff1); // Player chooses Buff 1
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                SelectBuff(randomBuff2); // Player chooses Buff 2
            }}
        else
        {
             if (Input.GetKeyDown(KeyCode.J))
            {
                SelectBuff(randomBuff1); // Player chooses Buff 1
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                SelectBuff(randomBuff2); // Player chooses Buff 2
            }
        }
        
    }

    void ActivateRandomBuffs()
    {
        // Generate two random buffs and activate them
        randomBuff1 = Random.Range(1, 5); // Assuming you have two buffs (Buff 1 and Buff 2)
        randomBuff2 = Random.Range(1, 5);
        Debug.Log(randomBuff1);
        Debug.Log(randomBuff2);
        ActivateBuff(randomBuff1, spriteRenderer1);
        ActivateBuff(randomBuff2, spriteRenderer2);
    }

    void ActivateBuff(int buffNumber, SpriteRenderer spriteRenderer)
    {
        // Implement logic to activate the chosen buff based on buffNumber and assign the sprite to the spriteRenderer
        switch (buffNumber)
        {
            case 1:
                spriteRenderer.sprite = _adrenaline;
                break;
            case 2:
                spriteRenderer.sprite = _boot;
                break;
            case 3:
                spriteRenderer.sprite = _baseballBat;
                break;
            case 4:
                spriteRenderer.sprite = _taser;
                break;
            default:
                spriteRenderer.sprite = none;
                break;
        }
    }

    void SelectBuff(int buffNumber)
    {
        Debug.Log("NUMERO DO BUFFER " + buffNumber);
        switch (buffNumber)
        {
            case 1:
                adrenalinaInstance.Adrenalina(_colliderPlayer);
                ActivateBuff(0, spriteRenderer1);
                ActivateBuff(0, spriteRenderer2);
                break;
            case 2:
                doubleJumpInstance.Double_Jump(_colliderPlayer);
                ActivateBuff(0, spriteRenderer1);
                ActivateBuff(0, spriteRenderer2);
                break;
            case 3:
                baseballBatInstance.Baseball_Bat(_colliderPlayer);
                ActivateBuff(0, spriteRenderer1);
                ActivateBuff(0, spriteRenderer2);
                break;
            case 4:
                taserColliderInstance.taser_choosed(_colliderPlayer);
                ActivateBuff(0, spriteRenderer1);
                ActivateBuff(0, spriteRenderer2);
                break;
            default:
                Debug.LogError("Invalid buffNumber");
                break;
        }
    }
    
}
