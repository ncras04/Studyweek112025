using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene("SampleScene");
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadmyScene() 
    {
        SceneManager.LoadScene("SampleScene");
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
