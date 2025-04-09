using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public void SelectLevel(int i){
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(i));
    }
}
