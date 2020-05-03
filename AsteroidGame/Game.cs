using System;
using System.Windows.Forms;
using System.Drawing;


namespace AsteroidGame
{


    static class Game
    {
        static Bitmap image;
        static Ship ship;

        // Графическое устройство для вывода графики            
        static Graphics g;

        static BaseObject[] objs;

        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;

        // Свойства
        // Ширина и высота игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }

        static Game()
        {
        }

        static public void Init(Form form)
        {
            
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();// Создаём объект - поверхность рисования и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
           
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            image = new Bitmap(@"background.bmp", true);


            form.KeyDown += Form_KeyDown;



            Load();

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        static private void Form_KeyDown(object sender, KeyEventArgs e)
        {
           // if (e.KeyCode == Keys.ControlKey) bullet = new Bullet(new Point(ship.Rect.X + 10, ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        static public void Load()
        {

            

            ship=new Ship(new Point(30,400),new Point(5,5),new Size(150,94));

            objs = new BaseObject[20];
        //    for (int i = 0; i < 10; i++)
        //        objs[i] = new Asteroid(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            for (int i = 0; i < 15; i++)
                objs[i] = new Star(new Point(600-i*10, i * 30), new Point(-i-2, 0), new Size(50, 50));
            for (int i = 15; i < 20; i++)
                objs[i] = new Rock(new Point(600, i * 20), new Point(25 - i, 26 - i), new Size(70, 70));
        }

        static public void Draw()
        {
        //    buffer.Graphics.Clear(Color.Black);

            buffer.Graphics.DrawImage(image, 0, 0);

            //g.DrawImage(image, 0, 0);

            foreach (BaseObject obj in objs)
                obj.Draw();

            ship.Draw();

            buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();
        }

    }
}
