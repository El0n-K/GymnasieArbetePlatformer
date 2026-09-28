using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Transform respawnLocation;
    [SerializeField] GameObject player;
    [SerializeField] LevelText levelText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("DeathObject"))
        {
            player.transform.position = respawnLocation.position;
            levelText.UpdateDeaths();
        }
    }
}
