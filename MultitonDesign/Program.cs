using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultitonDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera1 = Camera.GetInstance("CANON");
            Camera camera2 = Camera.GetInstance("CANON");
            Camera camera3 = Camera.GetInstance("NIKON");
            Camera camera4 = Camera.GetInstance("NIKON");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);

            Console.ReadLine();
        }
    }
    class Camera
    {
        private static object _lock = new object();
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        public Guid Id { get; set; }
        private Camera()
        {
            Id = Guid.NewGuid();
        }
        public static Camera GetInstance(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
