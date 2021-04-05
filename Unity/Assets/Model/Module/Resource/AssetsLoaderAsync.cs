using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    public class AssetsLoaderAsyncAwakeSystem: AwakeSystem<AssetsLoaderAsync, AssetBundle>
    {
        public override void Awake(AssetsLoaderAsync self, AssetBundle a)
        {
            self.Awake(a);
        }
    }

    public class AssetsLoaderAsyncUpdateSystem: UpdateSystem<AssetsLoaderAsync>
    {
        public override void Update(AssetsLoaderAsync self)
        {
            self.Update();
        }
    }

    public class AssetsLoaderAsync: Entity
    {
        private AssetBundle assetBundle;

        private AssetBundleRequest request;

        private ETTaskCompletionSource tcs;

        public void Awake(AssetBundle ab)
        {
            assetBundle = ab;
        }

        public void Update()
        {
            if (!request.isDone)
            {
                return;
            }

            ETTaskCompletionSource t = tcs;
            t.SetResult();
        }

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            base.Dispose();

            assetBundle = null;
            request = null;
        }

        public async ETTask<UnityEngine.Object[]> LoadAllAssetsAsync()
        {
            await InnerLoadAllAssetsAsync();
            return request.allAssets;
        }

        private ETTask InnerLoadAllAssetsAsync()
        {
            tcs = new ETTaskCompletionSource();
            request = assetBundle.LoadAllAssetsAsync();
            return tcs.Task;
        }
    }
}