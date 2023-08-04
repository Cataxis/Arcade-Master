using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private CanvasGroup group;

    private bool isChangingScene = false;

    public event Action OnSceneLoaded;

    public void ChangeScene(string _sceneName, float _waitTime, float _fadeDuration)
    {
        if (isChangingScene) return;

        StartCoroutine(ChangeSceneRoutine());

        IEnumerator ChangeSceneRoutine()
        {
            isChangingScene = true;
            bool canContinue = false;
            group.LeanAlpha(1f, _fadeDuration).setOnComplete(() => { canContinue = true;});
            while (!canContinue) yield return null;

            SceneManager.LoadScene(_sceneName);
            yield return new WaitForSeconds(_waitTime);

            canContinue = false;
            group.LeanAlpha(0f, _fadeDuration).setOnComplete(() => { canContinue = true; });
            while (!canContinue) yield return null;
            isChangingScene = false;

            OnSceneLoaded?.Invoke();
        }
    }
    public void ChangeScene(string _sceneName)
    {
        ChangeScene(_sceneName, .5f, fadeDuration);
    }
    public void ChangeScene(int _sceneindex)
    {
        string sceneName = SceneManager.GetSceneByBuildIndex(_sceneindex).ToString();
        ChangeScene(sceneName, .5f, fadeDuration);
    }
    public void ChangeScene(int _sceneindex, float _waitTime, float _fadeDuration)
    {
        string sceneName = SceneManager.GetSceneByBuildIndex(_sceneindex).ToString();
        ChangeScene(sceneName, _waitTime, _fadeDuration);
    }
}
