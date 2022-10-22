using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            //difendisEnjecktion araştırılacak
            CustomerManger customerManger = new CustomerManger();
            customerManger.messageSenderBase = new SmsSender();
            customerManger.UpdateCustomer();
            Console.ReadLine();
        }
    }
    abstract class MessageSenderBase
    {
        public void save()
        {
            Console.WriteLine("Message Save");
        }
        public abstract void Send(Body body);
    }
    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} Was sent via Smssender",body.Title);
        }
    }
    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} Was sen via Emailsender",body.Title);
        }
    }
    //.....
    class CustomerManger
    {
        public MessageSenderBase messageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            messageSenderBase.Send(new Body {Title="About the course" });
            Console.WriteLine("Customer Update");
        }
    }
}
