namespace RestWCFServiceLibrary
{
    public class TeacherService : ITeacherService
    {
        public string XMLData(string id)
        {
            return Data(id);
        }
        public string JSONData(string id)
        {
            return Data(id);
        }

        private string Data(string id)
        {
            // logic
            return "Data: " + id;
        }
    }
}