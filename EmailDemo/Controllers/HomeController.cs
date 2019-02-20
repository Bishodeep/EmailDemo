using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmailDemo.Models;

namespace EmailDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.ToEmail));  // replace with valid value 
                message.To.Add("mistye999@gmail.com");  // replace with valid value 
                message.To.Add("Kaushtup103@gmail.com");  // replace with valid value 
                message.From = new MailAddress(model.FromEmail);  // replace with valid value
                message.Subject = model.Subject;
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                if (model.Upload != null && model.Upload.ContentLength > 0)
                {
                    message.Attachments.Add(new Attachment(model.Upload.InputStream, Path.GetFileName(model.Upload.FileName)));
                }
                try
                {
                    using (var smtp = new SmtpClient())
                    {
                        //var credential = new NetworkCredential
                        //{
                        //    UserName = "bisowray1069@gmail.com",  // replace with valid value
                        //    Password = "*********"  // replace with valid value
                        //};
                        //smtp.Credentials = credential;
                        //smtp.Host = "smtp.gmail.com";
                        //smtp.Port = 587;
                        //smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);
                        return RedirectToAction("Sent");
                    }
                }
                catch (Exception e)
                {
                    return View();
                    throw;
                }
               
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}