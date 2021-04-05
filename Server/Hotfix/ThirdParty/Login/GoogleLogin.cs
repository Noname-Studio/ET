using System;
using ET.Utils;
using Google.Apis.Auth;

namespace ET.ThirdParty.Login
{
    public class GoogleLogin
    {
        public static async ETTask<long> Auth(string token)
        {
            try
            {
                var x = await GoogleJsonWebSignature.ValidateAsync(token);
                var userId = x.Subject;
                long trueId;
                if (long.TryParse(userId, out trueId))
                    return trueId;
                trueId = UniqueIdUtils.GetChecksum(userId);
                return trueId;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return 0;
        }
    }
}