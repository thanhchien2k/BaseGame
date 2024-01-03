using UnityEngine;

namespace BaseGame.Sngletons
{
    public class SingletonPersistem : MonoBehaviour
    {
        private static SingletonPersistem _instance;
        public static SingletonPersistem Instance
        {
            get
            {
                if (_instance == null)
                {
                    SetupInstance();
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }

        private static void SetupInstance()
        {

            _instance = FindObjectOfType<SingletonPersistem>();

            if (_instance == null)
            {
                GameObject gameObj = new GameObject();
                gameObj.name = "Singleton";
                _instance = gameObj.AddComponent<SingletonPersistem>();
                DontDestroyOnLoad(gameObj);
            }
        }
    }
}
