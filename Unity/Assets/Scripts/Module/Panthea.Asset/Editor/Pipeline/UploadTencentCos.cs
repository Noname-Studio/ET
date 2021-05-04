using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using COSXML;
using COSXML.Auth;
using COSXML.Model.Object;
using COSXML.Transfer;
using Force.Crc32;
using NPOI.SS.Formula.Functions;
using Panthea.Asset;
using Tencent.Cos;
using UnityEditor;
using UnityEngine;

namespace Panthea.Editor.Asset
{
    public class UploadTencentCos : AResPipeline
    {
        private TransferManager InitTransfer()
        {
            string appid = "1253480967";
            string region = "ap-guangzhou";
            CosXmlConfig config = new CosXmlConfig.Builder()
                    .IsHttps(true)
                    .SetRegion(region)
                    .SetDebugLog(true)
                    .Build();

            string secretId = "AKIDWo1BUZ6OxGK0ZxR9yXCbt68ubkdOmBU5";
            string secretKey = "WGuTtALUKvUYM0Ok0WngKkeI2ZtwyFG9";
            long durationSecond = 600; //每次请求签名有效时长，单位为秒
            QCloudCredentialProvider cosCredentialProvider = new DefaultQCloudCredentialProvider(secretId, secretKey, durationSecond);
            CosXml cosXml = new CosXmlServer(config, cosCredentialProvider);
            TransferConfig transferConfig = new TransferConfig();
            return new TransferManager(cosXml, transferConfig);
        }
        
        public override async Task Do()
        {
            try
            {
                var transfer = InitTransfer();
                var dir = new DirectoryInfo(BuildPreference.Instance.OutputPath);
                List<Task> tasks = new List<Task>();
                EditorUtility.DisplayProgressBar("正在上传文件到Cos服务器", "上传中...", 0);
                foreach (var node in dir.GetFiles())
                {
                    if (node.Extension == AssetsConfig.Suffix || node.Extension == ".json")
                    {
                        string key = "resources/" + EditorUserBuildSettings.activeBuildTarget.ToString().ToLower() + "/" +
                                PathUtils.FormatFilePath(node.FullName).Replace(BuildPreference.Instance.OutputPath, "");
                        PutObjectRequest request = new PutObjectRequest(CosConfig.Bucket, key, node.FullName);
                        request.IsHttps = true;
                        var crc32 = Crc32Algorithm.Compute(node.FullName);
                        request.SetRequestHeader("x-cos-meta-crc32", Crc32Algorithm.Compute(node.FullName).ToString());
                        request.IsNeedMD5 = true;
                        var config = new COSXMLUploadTask(request);
                        config.SetSrcPath(node.FullName);
                        var result = await transfer.UploadAsync(config);
                        var x = await FileStorageManager.Inst.Download(CosConfig.Bucket, key, AssetsConfig.PersistentDataPath + key);
                        var downloadcrc = int.Parse(x.responseHeaders["x-cos-meta-crc32"][0]);
                        crc32 = Crc32Algorithm.Compute(AssetsConfig.PersistentDataPath + key);
                        Log.Error(downloadcrc == crc32);
                        break;
                        tasks.Add(transfer.UploadAsync(config));
                        break;
                    }
                }

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }
    }
}