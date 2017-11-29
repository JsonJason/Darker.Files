using System;
using Darker.Persistance;

namespace Darker.UI.Persistance
{
    public class PersistanceFormController
    {
        private readonly Storage _storage;

        public Form1 View { get; set; }

        public PersistanceFormController(Storage storage)
        {
            _storage = storage;
        }

        public void LoadMessage()
        {
            try
            {

                View.Message = _storage.Load<TestMessage>().MessageContent;

                View.StatusReport("Loaded Message");
            }
            catch (Exception ex)
            {
                View.Error(ex);
            }
        }

        public void SaveMessage()
        {  
            try
            {

                _storage.Save(CreateMessage(View.Message));
                View.StatusReport("Save Successful!");
            }
            catch (Exception ex)
            {
                View.Error(ex);
            }
        }

        TestMessage CreateMessage(string content)
        {
            return new TestMessage
            {
                Author = "Jason",
                Created = DateTime.UtcNow,
                MessageContent = content
            };
        }

    }


    public class TestMessage
    {
        public DateTime Created { get; set; }
        public string MessageContent { get; set; }
        public string Author { get; set; }
    }

}