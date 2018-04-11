using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lib
{
    public class ResourceManager
    {
        private static Dictionary<string, UnityEngine.Object> resources = new Dictionary<string, UnityEngine.Object>();

        //获取资源
        public static T GetResource<T>(string url) where T : class
        {
            if (resources.ContainsKey(url) == false)
            {
                resources.Add(url, Resources.Load(url));
                Resources.UnloadUnusedAssets();
            }
            return resources[url] as T;
        }
    }

}