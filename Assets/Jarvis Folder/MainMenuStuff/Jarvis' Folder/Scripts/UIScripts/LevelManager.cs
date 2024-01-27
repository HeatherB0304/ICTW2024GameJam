using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Image _progressBar;

    void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);

        while (scene.progress < 0.9f)
        {
            _progressBar.fillAmount = scene.progress;
            await Task.Delay(1);
        }

        scene.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
    }
}
