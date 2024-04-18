using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg.inter.korvariant
{
    //public interface IMessage
    //{
    //    public string Text { get; }

    //}

    //public interface IMessanger<out T>
    //{
    //    T SendMessage(string text);
    //}



    //public class Telegram : IMessanger<TelegramMessage>
    //{
    //    public TelegramMessage SendMessage(string text)
    //    {
    //        return new TelegramMessage($"TG: {text}");
    //    }    
    //}


    //public class TelegramMessage : IMessage
    //{
    //    public string Text { get; }

    //    public TelegramMessage(string text)
    //    {
    //        Text = text;
    //    }

    //}




    class Message
    {
        public string Text { get; }
        public Message(string text) => Text = text;
        public virtual void Print() => Console.WriteLine($"Message: {Text}");
    }
    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
        public override void Print() => Console.WriteLine($"Email: {Text}");
    }
    class SmsMessage : Message
    {
        public SmsMessage(string text) : base(text) { }
        public override void Print() => Console.WriteLine($"Sms: {Text}");
    }

    delegate Message MessageBuilder(string text);




    internal class Program
    {
        public static void Test1()
        {
            //IMessanger<TelegramMessage> telegram = new Telegram();

            //IMessage message = telegram.SendMessage("ff");

            //Console.WriteLine(message.Text); 

            //Console.WriteLine("tt");
        }

        public static void Test2() 
        {
            MessageBuilder messageBuilder = writeEmailMessage;

            Message message = messageBuilder("idz do pizdy!!!");

            message.Print();


            EmailMessage writeEmailMessage(string text) => new EmailMessage(text);
        }


        public static void Start()
        {
            Test1();
            Test2();




        }
    }
}
