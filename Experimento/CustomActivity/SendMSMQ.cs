using System;
using System.Activities;
using System.Threading;
using System.Messaging;

namespace CustomActivity
{
    public sealed class SendMSMQ : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> nomeFila { get; set; }
        [RequiredArgument]
        public InArgument<object> data { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            if (!MessageQueue.Exists(nomeFila.Get(context))) 
            {
                MessageQueue.Create(nomeFila.Get(context));
            }

            MessageQueue MQueue = new MessageQueue(nomeFila.Get(context));

            Message Msg = new Message(data.Get(context));

            Msg.AcknowledgeType = AcknowledgeTypes.FullReceive;

            Msg.Priority = MessagePriority.Normal;

            MQueue.Send(Msg);
        }
    }
}