using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamagable
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [Tooltip("Detiene al jugador en esa posición negativa y  positiva en el eje horizontal")]
    [SerializeField] private float bounds = 4.5f;

    private bool isPaused = false;


    private GeneralInputController input;

    private void Start()
    {
        input = GeneralGlobal.Instance.InputController;
    }

    void Update()
    {
        if (!isPaused)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            RestartScene();
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            TogglePauseGame();
        }
    }
    private void Move()
    {
        float xInput = input.GetInputDirection().x;
        Vector2 playerPosition = transform.position;
        playerPosition.x += xInput * moveSpeed * Time.deltaTime;
        playerPosition.x = Mathf.Clamp(playerPosition.x, -bounds, bounds);

        transform.position = playerPosition;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void TogglePauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(Vector3.right * bounds, .4f);
        Gizmos.DrawSphere(Vector3.right * -bounds, .4f);
    }

    public void Damage()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
