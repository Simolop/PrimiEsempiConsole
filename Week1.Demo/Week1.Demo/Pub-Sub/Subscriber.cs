﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo.Pub_Sub
{
    class Subscriber
    {
        public string SubscriberName { get; set; }

        public Subscriber (string subscriberName)
        {
            SubscriberName = subscriberName;
        }

        //Metodi subscribe e unsuscribe
        public void Subscribe(Publisher p)
        {
            //registro alla notifica dell'evento
            p.OnPublish += OnNotificationReceived;
        }

        public void Unsubscribe(Publisher p)
        {
            p.OnPublish -= OnNotificationReceived;
        }

        //metodo che gestisce la notifica dell'evento
        public void OnNotificationReceived(Publisher p, Notification n)
        {
            Console.WriteLine("Ciao, " + SubscriberName + " notifica ricevuta da " + p.PublisherName + " il giorno " + n.NotificationDate + " : " + n.NotificationMessage);
        }
    }
}
