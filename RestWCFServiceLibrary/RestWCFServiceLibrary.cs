using Amazon.Kinesis.Model;
using Amazon.Kinesis;
using System;
using System.Threading.Tasks;

namespace RestWCFServiceLibrary
{
    public class RestWCFServiceLibrary : IRestWCFServiceLibrary
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
            return "Data: " + id;
        }

        private async void ToKinesis(string id)
        {
            var kinesis = new AmazonKinesisClient();
            var request = new PutRecordRequest();
            PutRecordResponse response;

            try
            {
                // TODO: Confifure kinesis connection
                // TODO: Add AWS Profile to AWS Toolkit and operating system
                // TODO: Specify shard
                // TODO: Setup Middleware
                // TODO: Use PutRecords instead
                response = await kinesis.PutRecordAsync(request);
            }
            catch (Exception e)
            {
                // TODO: Try again
            }
        }
    }
}