using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public int sceneChange = 0;
    public void Update()
    {
        if (sceneChange>0){
            SelectLevel(sceneChange);
            sceneChange = 0;
        }
    }
    public void SelectLevel(int i){
        SceneManager.LoadScene(i);
    }
}
