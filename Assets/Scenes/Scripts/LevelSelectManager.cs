using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager instance;
    public int sceneChange;

    public void Start()
    {
        if (instance){
            Destroy(this);
            return;
        }
        instance = this;   
    }
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
