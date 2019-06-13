using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using uStoreProject.Models;

namespace uStoreProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Laptops()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(contactInfo);
            }

            string body = string.Format(
                $"Name: {contactInfo.Name}<br />"
                + $"Email: {contactInfo.Email}<br />"
                + $"Subject: {contactInfo.Subject}<br />"
                + $"Message:<br />{contactInfo.Message}");

            MailMessage msg = new MailMessage(
                "no-reply@turnermadick.com",
                "tcmadick@gmail.com",
                contactInfo.Subject,
                body);

            //3. Set properties of the MailMessage object (CC, BCC, set mail priority, etc.)
            msg.IsBodyHtml = true;
            msg.CC.Add("email@domain.com");
            //msg.Priority = MailPriority.High; //priority of email (flag)

            //4. Create and configure the SMTP client (this is what will actually send the email)
            SmtpClient client = new SmtpClient("mail.turnermadick.com");
            client.Credentials =
                new NetworkCredential("no-reply@turnermadick.com",
                "P@ssw0rd");
            client.EnableSsl = false;
            client.Port = 25;

            //5. Use the SMTP client object to try and send the email message.
            //We will need to make sure that we close the SMTP client object
            //when we are done trying to send the email
            using (client)
            {
                //automatically close/clean-up resources related to the SmtpClient object
                //(Garbage Collection)

                try
                {
                    //We are going TRY to send the email (with our client)
                    client.Send(msg);
                }//try
                catch
                {
                    //FAILED TO SEND - we will add a message and display it to the user on the _Layout
                    //Create a ViewBag object to return an error to the user
                    //and send them back to the Contact View
                    ViewBag.ErrorMessage = "There was an error sending your message.\n"
                        + "Please try again.";
                    return View();
                    //return View(contactInfo);
                }//catch
            }//using --client

            //SENT SUCCESSFUL - Send the user to a "ContactConfirmation" View and
            //send the contactInfo object with it (user the sender's name)
            //return View(); //return something (temporary) to remove syntax errors

            return View("ContactConfirmation", contactInfo);
        }
    }
}