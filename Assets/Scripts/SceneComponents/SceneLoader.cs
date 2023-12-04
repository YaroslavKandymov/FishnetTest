using UnityEngine.SceneManagement;

namespace FishNet.SceneComponents
{
    public class SceneLoader
    {
        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}