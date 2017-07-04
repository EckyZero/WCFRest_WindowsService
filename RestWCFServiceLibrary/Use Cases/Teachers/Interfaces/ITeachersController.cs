using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestWCFServiceLibrary.Use_Cases.Teachers.Interfaces
{
    [ServiceContract]
    public interface ITeachersController
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "{id}")]
        string Get(string id);
    }
}
