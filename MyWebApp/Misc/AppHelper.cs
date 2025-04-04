﻿using System.Net.Mail;
using System.Net;
using System.Text;
using QRCoder;
using System.Drawing;

namespace MyWebApp.Misc
{
	public static class AppHelper
	{
		public static string CreatePassword()
		{
			int len = 10;
			string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

			Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

			StringBuilder res = new StringBuilder();

			while (0 <= len--)
			{
				res.Append(valid[rnd.Next(valid.Length)]);
			}

			return res.ToString();
		}
	}

	public static class EmailHelper
	{
		public static void SendEmail(string email, string displayName, string pwd, string selCondo, int selCondoNumber)
		{
			string sender = "brav850@gmail.com";
			string senderPwd = "uuxn chws incl ssjj";

			//string sender = "";
			//string senderPwd = "";

			using (MailMessage mm = new MailMessage(sender, email))
			{
				mm.Subject = "Bienvenido al Sistema Automatico de Condominios";
				mm.IsBodyHtml = true;

				using (var sr = new StreamReader("wwwroot/templates/welcome.html"))
				{
					string body = sr.ReadToEnd().Replace("{usuario}", displayName);
					body = body.Replace("{email}", email);
					body = body.Replace("{password}", pwd);
					body = body.Replace("{condominio}", selCondo);
					body = body.Replace("{numero_casa}", selCondoNumber.ToString());
					mm.Body = body;
				}

				SmtpClient smtp = new SmtpClient();
				smtp.Host = "smtp.gmail.com";
				smtp.EnableSsl = true;
				NetworkCredential NetworkCred = new NetworkCredential(sender, senderPwd);
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = NetworkCred;
				smtp.Port = 587;
				smtp.Send(mm);
			}
		}
	}

	public static class QRGenerator
	{
		public static string GenerateQRCode()
		{
			string content = AppHelper.CreatePassword();
			string path = "wwwroot/qr/" + content + ".png";

			QRCodeGenerator qrGenerator = new QRCodeGenerator();

			QRCodeData data = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);

			QRCode qrCode = new QRCode(data);

			Bitmap bit = qrCode.GetGraphic(20);

			bit.Save(path);

			return path.Replace("wwwroot", string.Empty);
		}
	}
}
