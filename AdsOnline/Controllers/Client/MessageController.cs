using AdsOnline.Models.Data;
using AdsOnline.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AdsOnline.Controllers.Client
{
    [Authorize]
    public class MessageController : Controller
    {
        AdsContext context = new AdsContext();
        // GET: Message
        
        public ActionResult InComingMessages()
        {
            var mail = (string)Session["UserMail"];
            var messages = context.Messages.Where(x => x.Receiver == mail).OrderByDescending(x => x.Id).ToList();
            var numberOfIncomingMessages = context.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.numberOfIncomingMessages = numberOfIncomingMessages;
            var numberOfSentMessages = context.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.numberOfSentMessages = numberOfSentMessages;
            return View(messages);
        }
        
        public ActionResult SentMessages()
        {
            var mail = (string)Session["UserMail"];
            var messages = context.Messages.Where(x => x.Sender == mail).OrderByDescending(x => x.Id).ToList();
            var numberOfSentMessages = context.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.numberOfSentMessages = numberOfSentMessages;
            var numberOfIncomingMessages = context.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.numberOfIncomingMessages = numberOfIncomingMessages;
            return View(messages);
        }
        
        public ActionResult MessageDetail(int id)
        {
            var messages = context.Messages.Where(x => x.Id == id).ToList();
            var mail = (string)Session["UserMail"];
            var numberOfSentMessages = context.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.numberOfSentMessages = numberOfSentMessages;
            var numberOfIncomingMessages = context.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.numberOfIncomingMessages = numberOfIncomingMessages;
            return View(messages);
        }
        
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["UserMail"];
            var numberOfSentMessages = context.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.numberOfSentMessages = numberOfSentMessages;
            var numberOfIncomingMessages = context.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.numberOfIncomingMessages = numberOfIncomingMessages;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            var mail = (string)Session["UserMail"];
            m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Sender = mail;
            context.Messages.Add(m);
            context.SaveChanges();

            return View();
        }
    }
}