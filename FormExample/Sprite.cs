using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FormExample
{
    public class Sprite
    {
        //instance variable
        Image Zergling = Image.FromFile("Zergling.png");
        private float d, r1, r2;
        private float s = 100;
        private float x = 0;

        public Sprite()
        {
            Random rand = new Random();
            d = rand.Next(1, 5);
            r1 = rand.Next(1, 1000);
            r2 = rand.Next(1, 500);
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        private float y = 0;

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        private float scale = 1;

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        protected List<Sprite> children = new List<Sprite>();

        public void clear()
        {
            children.Clear();
        }

        public void render(Graphics g)
        {
            Matrix original = g.Transform.Clone();
            g.ScaleTransform(scale, scale);
            g.TranslateTransform(x, y);
            paint(g);
            foreach (Sprite s in children)
            {
                s.render(g);
            }
            g.Transform = original;
        }

        public virtual void paint(Graphics g)
        {
            float v1;
            float v2;
            Image img;
            v1 = (float)(r1 + r1 * Math.Tan(s / 10));
            v2 = (float)(r2 + r2 * Math.Cos(s / 10));
            img = Zergling;
            g.DrawImage(img, v1, v2);
            s++;
        }

        public void add(Sprite s)
        {
            children.Add(s);
        }

        public long count()
        {
            return children.Count();
        }

    }
}
