using System;
using System.Runtime.Serialization;

namespace TencentWeiboSDK.Hammock.Web
{
#if !SILVERLIGHT
    [Serializable]
#endif
    public enum HttpPostParameterType
    {
#if !SILVERLIGHT && !Smartphone && !ClientProfiles && !NET20 && !MonoTouch
        [EnumMember] Field,
        [EnumMember] File
#else
        Field,
        File
#endif
    }
}