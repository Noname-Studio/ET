using System;
using UnityEngine.Networking;

namespace ET
{
    public class UnityWebRequestUpdateSystem: UpdateSystem<UnityWebRequestAsync>
    {
        public override void Update(UnityWebRequestAsync self)
        {
            self.Update();
        }
    }

    public class UnityWebRequestAsync: Entity
    {
        public class AcceptAllCertificate: CertificateHandler
        {
            protected override bool ValidateCertificate(byte[] certificateData)
            {
                return true;
            }
        }

        public static AcceptAllCertificate certificateHandler = new AcceptAllCertificate();

        public UnityWebRequest Request;

        public bool isCancel;

        public ETTaskCompletionSource tcs;

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            base.Dispose();

            Request?.Dispose();
            Request = null;
            isCancel = false;
        }

        public float Progress
        {
            get
            {
                if (Request == null)
                {
                    return 0;
                }

                return Request.downloadProgress;
            }
        }

        public ulong ByteDownloaded
        {
            get
            {
                if (Request == null)
                {
                    return 0;
                }

                return Request.downloadedBytes;
            }
        }

        public void Update()
        {
            if (isCancel)
            {
                tcs.SetException(new Exception($"request error: {Request.error}"));
                return;
            }

            if (!Request.isDone)
            {
                return;
            }

            if (!string.IsNullOrEmpty(Request.error))
            {
                tcs.SetException(new Exception($"request error: {Request.error}"));
                return;
            }

            tcs.SetResult();
        }

        public async ETTask DownloadAsync(string url)
        {
            tcs = new ETTaskCompletionSource();

            url = url.Replace(" ", "%20");
            Request = UnityWebRequest.Get(url);
            Request.certificateHandler = certificateHandler;
            Request.SendWebRequest();

            await tcs.Task;
        }
    }
}