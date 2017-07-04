using RestWCFServiceLibrary.Use_Cases.Teachers.Interfaces;

namespace RestWCFServiceLibrary.Use_Cases.Teachers
{
    public class TeachersController : ITeachersController
    {
        public string Get (string id)
        {
            return "You entered id: " + id;
        }
    }
}
