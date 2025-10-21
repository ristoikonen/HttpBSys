using System.Security.AccessControl;

namespace HttpBSys
{
    public interface IHttpRequestQueue
    {
        Task<string> GetHtmlContent(string url);
        // (bool isContainer:false, bool isDS: false, string sddlForm: string.Empty));
        Task<CommonSecurityDescriptor> GenerateCommonSecurityDescriptor(bool isContainer, bool isDS, string sddlForm);

    }
}
