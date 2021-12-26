using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Serialize_and_DeSerialize
{
    class Program : INotifyPropertyChanged
    {
        public static object BinaryDeSerialize()
        {



            if (!System.IO.File.Exists("1.bin")) { throw new NotImplementedException(); }

            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream fStream = File.OpenRead("1.bin"))
            {
                return formatter.Deserialize(fStream);
            }
        }

        public static void BinarySerialize(ObservableCollection<Files> files)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream fStream = new FileStream("1.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fStream, files);
            }

        }
        public ObservableCollection<Files> _fileList { get; set; }

        public ObservableCollection<Files> FileList { get { return _fileList; } set { _fileList = value; OnPropertyChanged(); } }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        static void add(ObservableCollection<Files> files)
        {



            files.Add(new Files()
            {
                FileShortName = $"{System.IO.Path.GetFileName($@"1.png")}",
                FileName = $"{System.IO.Path.GetFileName($@"1.png")}",
                FileAddDateTime = $" Add Time: {DateTime.Now.ToLocalTime()}",
                FilePath = $"{$@"1.png"}",
                FolderofFile = $" Folder of File: {$@".."}",
                FileİmagePath = $@"1.png",

            });

            files.Add(new Files()
            {
                FileShortName = $"{System.IO.Path.GetFileName($@"1.jpg")}",
                FileName = $"{System.IO.Path.GetFileName($@"1.jpg")}",
                FileAddDateTime = $" Add Time: {DateTime.Now.ToLocalTime()}",
                FilePath = $"{$@"1.jpg"}",
                FolderofFile = $" Folder of File: {$@" "}",
                FileİmagePath = $@"1.jpg",

            });
        }
        static void Main(string[] args)
        {
            ObservableCollection<Files> files = new ObservableCollection<Files>();

            FileStream stream = File.Create($@"C:\Users\Lenovo\Desktop\1.png");

            BinaryFormatter formatter = new BinaryFormatter();

            while (true)
            {
                string s = Console.ReadLine();

                if (s == "1")
                {
                    add(files);
                }
                if (s == "2")
                {
                    BinarySerialize(files);
                }
                if (s == "3")
                {
                    var deserializedList = BinaryDeSerialize();

                    ObservableCollection<Files> vs = (ObservableCollection<Files>)deserializedList;

                    foreach (var item in vs)
                    {
                        Console.WriteLine(item.FileName);
                    }
                }
            }

        }
    }
}
