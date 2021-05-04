using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using COSXML;
using COSXML.Auth;
using COSXML.Model.Object;
using COSXML.Transfer;
using Manager;
using UnityEngine;

namespace Tencent.Cos
{
    public class FileStorageManager: Singleton<FileStorageManager>
    {
        private TransferManager TransferManager { get; }
        private CosXml CosXml { get; }
        private FileStorageManager()
        {
            string appid = CosConfig.AppId;
            string region = CosConfig.Region;
            CosXmlConfig config = new CosXmlConfig.Builder()
                    .IsHttps(true)
                    .SetRegion(region)
                    .SetDebugLog(true)
                    .Build();

            string secretId = CosConfig.SecretId;
            string secretKey = CosConfig.SecretKey;
            long durationSecond = 600; //每次请求签名有效时长，单位为秒
            QCloudCredentialProvider cosCredentialProvider = new DefaultQCloudCredentialProvider(secretId, secretKey, durationSecond);
            CosXml = new CosXmlServer(config, cosCredentialProvider);
            TransferConfig transferConfig = new TransferConfig();
            TransferManager = new TransferManager(CosXml, transferConfig);
        }

        public async Task<COSXMLDownloadTask.DownloadTaskResult> Download(string bucket,string cosPath,string savePath)
        {
            string localDir = Path.GetDirectoryName(savePath); 
            string localFileName = Path.GetFileName(savePath);

            COSXMLDownloadTask downloadTask = new COSXMLDownloadTask(bucket, cosPath,
                localDir, localFileName);
            //downloadTask.progressCallback = delegate(long completed, long total)
            //{
            //    Log.Print($"progress = {completed * 100.0 / total:##.##}%");
            //};

            try
            {
                COSXMLDownloadTask.DownloadTaskResult result = await TransferManager.DownloadAsync(downloadTask);
                return result;
            }
            catch (Exception e)
            {
                Log.Error("Tencent.Cos.FileStorage.Exception: " + e);
            }

            return null;
        }

        public async Task<GetObjectBytesResult> GetBytes(string bucket, string cosPath)
        {
            GetObjectBytesRequest getObjectBytesRequest = new GetObjectBytesRequest(bucket, cosPath);
            //getObjectBytesRequest.SetCosProgressCallback(delegate (long completed, long total)
            //{
            //    Log.Print($"{DateTime.Now.ToString()} progress = {completed} / {total} : {completed * 100.0 / total:##.##}%");
            //});
            GetObjectBytesResult getObjectBytesResult = CosXml.GetObject(getObjectBytesRequest);
            return getObjectBytesResult;
        }
    }
}