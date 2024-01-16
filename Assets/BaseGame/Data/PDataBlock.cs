using BaseGame.Data;
using System;

namespace BaseGame.DataBlock
{
    public class PDataBlock<T> where T: PDataBlock<T>
    {
        private static T _instance;
        public static T Instance 
        {
            get 
            {
                if(_instance == null)
                {
                    _instance = DataHelper.Load<T>(typeof(T).ToString());
                    if( _instance != null ) 
                    {
                        _instance = (T)Activator.CreateInstance(typeof(T));
                    }
                    _instance.Init();
                }
                
                return _instance;
            }

        }

        private void Init() 
        {
            
        }

        private void Save()
        {
            DataHelper.Save(Instance, typeof(T).ToString());
        }

        private static void Delete()
        {
            _instance = null;
            DataHelper.Delete(typeof(T).ToString());
        }
    }
}
