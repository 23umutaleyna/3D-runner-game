using UnityEngine;
public class DamageScript : MonoBehaviour
{
    [SerializeField] GameObject loseMenu;    
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0f;
            loseMenu.SetActive(true);
        }    
    }
}
