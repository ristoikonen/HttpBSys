using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Security.Principal;

namespace HttpBSys
{
    public class HttpRequestQueue : IHttpRequestQueue
    {
        public async Task<CommonSecurityDescriptor> GenerateCommonSecurityDescriptor(bool isContainer, bool isDS, string sddlForm)
        { 
            int capacity = 2;

            var securityDescriptor = new CommonSecurityDescriptor(isContainer, isDS, sddlForm);

            //var dacl = new DiscretionaryAcl(isContainer, isDS, capacity);

            /*
                dacl.AddAccess(
                    AccessControlType.Allow,
                    new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null),
                    -1,
                    InheritanceFlags.None,
                    PropagationFlags.None
                );
                dacl.AddAccess(
                    AccessControlType.Deny,
                    new SecurityIdentifier(WellKnownSidType.BuiltinGuestsSid, null),
                    -1,
                    InheritanceFlags.None,
                    PropagationFlags.None
                );
            */
            
            return securityDescriptor;

        }


        public async Task<string> GetHtmlContent(string url)
        {
            using (HttpClient client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                // client.BaseAddress = new Uri("https://api.stackexchange.com/2.2/");
                // HttpResponseMessage response = client.GetAsync("answers?order=desc&sort=activity&site=stackoverflow").Result;

                HttpResponseMessage response = await client.GetAsync(url);
                //TODO handle exceptions
                response.EnsureSuccessStatusCode(); // Throws ex if not a success code
                return await response.Content.ReadAsStringAsync() ?? "";
            }
        }

        //public Task<string> GetHtmlContent(string url)
        //{
            // new NotImplementedException();
        //}
    }
}
/*
 
 I i = null;

    i.FooAsync();             // Does not warn
    // await i.FooAsync();    // Can't await in a non async method
    var t1 = i.FooAsync();    // Does not warn

    Task.Run(async () =>
    {
       i.FooAsync();          // Warns CS4014
       await i.FooAsync();    // Does not warn
       var t2 = i.FooAsync(); // Does not warn
    });

 */