﻿using iWeibo.WP7.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TencentWeiboSDK.Model;

namespace iWeibo.WP7.Models.TencentModels
{
    public class TencentConfig
    {
        private static string appKey = "801416703";

        public static string AppKey
        {
            get { return appKey; }
        }

        private static string appSecret = "65bde177b495cadc82acf2501a2e28ba";

        public static string AppSecret
        {
            get { return appSecret; }
        }

        public static bool Validate()
        {
            TencentAccessToken accessToken;
            if (TokenIsoStorage.TencentTokenStorage.TryLoadData<TencentAccessToken>(out accessToken))
            {

                return !string.IsNullOrWhiteSpace(accessToken.TokenKey);
            }
            return false;
        }

    }
}
