using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [Tooltip("Detiene al jugador en esa posición negativa y  positiva en el eje horizontal")]
    [SerializeField] private float bounds = 4.5f;

    private bool isPaused = false;

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
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 playerPosition = transform.position;
        float normalizedMoveSpeed = moveSpeed * Time.deltaTime * 60f;

        playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * normalizedMoveSpeed, -bounds, bounds);
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
}
