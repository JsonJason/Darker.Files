using System;
using Darker.Persistance;

namespace Darker.UI.Persistance
{
    public class PersistanceFormController : BaseController
    {
        private readonly Storage _storage;

        public new Form1 View => base.View as Form1;

        public PersistanceFormController(Storage storage)
        {
            _storage = storage;
        }

        public void LoadMessage() => 
            Try(() =>
            {

                View.Message = _storage.Load<TestMessage>().MessageContent;

                View.StatusUpdate("Loaded Message");
            });

        public void SaveMessage() => 
            Try(() =>
        {
            _storage.Save(CreateMessage(View.Message));
            View.StatusUpdate("Save Successful!");
        });
        

        TestMessage CreateMessage(string content)
        {
            return new TestMessage
            {
                Author = "Jason",
                Created = DateTime.UtcNow,
                MessageContent = content
            };
        }

        public void SetView(Form1 view)
        {
            base.View = view;
        }
    }


    public class TestMessage
    {
        public DateTime Created { get; set; }
        public string MessageContent { get; set; }
        public string Author { get; set; }
    }

}