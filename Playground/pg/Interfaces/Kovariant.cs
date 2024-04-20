using Playground.pg.inter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg.inter.korvariant
{



    class Message
    {
        public string Text { get; set; }
        public Message(string text) => Text = text;
    }
    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
    }

    //contrvariation
    interface IMessenger<in T>
    {
        void WriteMessage(T message);
    }

    class PlainMessenger : IMessenger<Message>
    {
        public void WriteMessage(Message message)
        {
            Console.WriteLine($"contrvariation : {message.Text}");
        }
    }






    //covariant
    //interface IMessenger<T>
    //{
    //    T WriteMessage(string text);
    //}



    //class PlainMessenger : IMessenger<Message>
    //{
    //    public Message WriteMessage(string text)
    //    {
    //        return new Message($"Plain: {text}");
    //    }
    //}

    //class EmailMessenger : IMessenger<EmailMessage>
    //{
    //    public EmailMessage WriteMessage(string text)
    //    {
    //        return new EmailMessage($"Email: {text}");
    //    }
    //}






    //class Message
    //{
    //    public string Text { get; }
    //    public Message(string text) => Text = text;
    //    public virtual void Print() => Console.WriteLine($"Message: {Text}");
    //}
    //class EmailMessage : Message
    //{
    //    public EmailMessage(string text) : base(text) { }
    //    public override void Print() => Console.WriteLine($"Email: {Text}");
    //}
    //class SmsMessage : Message
    //{
    //    public SmsMessage(string text) : base(text) { }
    //    public override void Print() => Console.WriteLine($"Sms: {Text}");
    //}

    //delegate Message MessageBuilder(string text);




    internal class Program
    {
        public static void Test1()
        {
            //IMessanger<TelegramMessage> telegram = new Telegram();

            //IMessage message = telegram.SendMessage("ff");

            //Console.WriteLine(message.Text);
            //Console.WriteLine("tt");



            //IMessenger<Message> outlook = new EmailMessenger();
            //Message message = outlook.WriteMessage("Hello World");
            //Console.WriteLine(message.Text);    // Email: Hello World


            //IMessenger<Message> plainMessenger = new PlainMessenger();
            //Message msssg = plainMessenger.WriteMessage("i want to know");
            //Console.WriteLine(msssg.Text);


            //contrvariation
            IMessenger<EmailMessage> plainMessenger = new PlainMessenger();
            plainMessenger.WriteMessage(new EmailMessage("hi"));
            

            //IMessenger<EmailMessage> emailClient = new EmailMessenger();
            //IMessenger<Message> messenger = emailClient;
            //Message emailMessage = messenger.WriteMessage("Hi!");
            //Console.WriteLine(emailMessage.Text);    // Email: Hi!

            //IMessenger<EmailMessage> emailClient2 = new EmailMessenger();
            //Message msg = emailClient2.WriteMessage("Helloooooo");
            //Console.WriteLine(msg.Text);

        }

        //public static void Test2() 
        //{
        //    MessageBuilder messageBuilder = writeEmailMessage;

        //    Message message = messageBuilder("idz do pizdy!!!");

        //    message.Print();


        //    EmailMessage writeEmailMessage(string text) => new EmailMessage(text);
        //}






        //test 3
        public class Fruit
        {
            public string Name { get; }

            public Fruit(string name) => Name = name;
        }

        public class Apple : Fruit
        {
            string Name { get; }

            public Apple(string name) : base(name) { }


        }

        public class Banana : Fruit
        {
            public Banana(string name) : base(name) { } 
        }

        interface IBag<in T>
        {
            public void OpenBag(T obj);
        }


        //contrvariation
        class BagOfFruits : IBag<Fruit>
        {
            public void OpenBag(Fruit fruit)
            {
                Console.WriteLine($"bag of fruits: {fruit.Name}");
            }
        }


        class BagOfApple : IBag<Apple>
        {
            public void OpenBag(Apple apple)
            {
                Console.WriteLine($"bag of apples: {apple.Name}");
            }
        }



        //covariaton

        //class BagOfApples : IBag<Apple>
        //{
        //    public Apple OpenBag()
        //    {
        //        return new Apple();
        //    }
        //}


        //class BagOfFruits : IBag<Fruit>
        //{
        //    public Fruit OpenBag()
        //    {
        //        return new Fruit();
        //    }
        //}






        public static void Test3()
        {
            // invariant
            //IBag<Apple> bagOfFruit = new BagOfApples();
            //Apple apple = bagOfFruit.OpenBag();
            //Console.WriteLine(apple.GetType().Name);

            //covariant 
            //IBag<Fruit> bagOfFruit2 = new BagOfApples();
            //Fruit fruit = bagOfFruit2.OpenBag();
            //Console.WriteLine(fruit.GetType().Name);

            //contrvariant
            IBag<Apple> bagOfApples = new BagOfFruits();
            bagOfApples.OpenBag(new Apple("jonagold"));


        }

        public static void Start()
        {
            //Test1();
            //Test2();
            Test3();



        }
    }
}
