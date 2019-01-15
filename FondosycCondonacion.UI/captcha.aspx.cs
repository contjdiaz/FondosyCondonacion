using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FondosycCondonacion.UI
{
    public partial class captcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SetVerificationText();
            }
        }

        //INICIO DEL CAPTCHA NUEVO
        public void SetVerificationText()
        {
            String no = RandomString(5);
            Context.Session.Add("Captcha", no.ToString());
            this.GenerarImagen();
        }

        public void GenerarImagen()
        {
            Bitmap bmpOut = new Bitmap(130, 50);
            Graphics g = Graphics.FromImage(bmpOut);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            Color FondoRect, gris, amarillo, rojo, azul;
            rojo = Color.FromArgb(248, 211, 214);
            amarillo = Color.FromArgb(253, 249, 196);
            gris = Color.FromArgb(197, 198, 200);
            azul = Color.FromArgb(152, 199, 235);
            FondoRect = Color.FromArgb(255, 255, 255);
            //Rectangulo base color blanco
            SolidBrush FondoRectangulo = new SolidBrush(FondoRect);
            Pen pen1 = new Pen(rojo);
            Pen pen2 = new Pen(amarillo);
            Pen pen3 = new Pen(gris);
            Pen pen4 = new Pen(azul);

            g.FillRectangle(FondoRectangulo, 0, 0, 130, 50);

            Random ran = new Random();
            int gran1, gran2, gran3, angle1, angle2, angle3 = 0;

            for (int ctr = 0; ctr <= 20; ctr++)
            {
                gran1 = ran.Next(130);
                gran2 = ran.Next(50);
                gran3 = ran.Next(50);
                angle1 = ran.Next(360);
                angle2 = ran.Next(360);
                angle3 = ran.Next(360);

                Rectangle rect1 = new Rectangle(gran1 - 50, gran2 - 10, 80, 40);
                Rectangle rect2 = new Rectangle(0, 0, 130 - gran1, 50 - gran2);
                Rectangle rect3 = new Rectangle(0, 0, 130 - gran1, 50 - gran3);
                g.DrawArc(pen1, rect1, 0, angle1);
                g.DrawArc(pen2, rect2, 0, angle2);
                g.DrawArc(pen3, rect3, 0, angle3);
                g.DrawLine(pen4, 0, 50, gran1, gran3);
            }

            string display = null;
            display = Context.Session["Captcha"].ToString();
            g.DrawString(display.ToString(), new Font("Palatino Linotype", 20), new SolidBrush(Color.FromArgb(119, 74, 41)), 3, 8);
            MemoryStream ms = new MemoryStream();
            bmpOut.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bmpBytes = ms.GetBuffer();
            bmpOut.Dispose();
            ms.Close();
            Context.Response.BinaryWrite(bmpBytes);
            Context.Response.End();
        }

        private readonly Random _rng = new Random();
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

        private string RandomString(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}