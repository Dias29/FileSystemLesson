using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DirectoryLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             FileStream - rabotaet s baitami
             StreamReader/StreamWriter - rabotaet s textom
             BinaryReader/BinaryWriter - rabotaet s failami .bin
             */
            string text = "mama myla ramu";
            byte[] source = Encoding.UTF32.GetBytes(text);

            using (FileStream stream = new FileStream(@"C:\name_of_directory\MyFile.txt", FileMode.OpenOrCreate))
            {
                stream.Write(source, 0, source.Length);
            }

            // byte[] reciever = File.ReadAllBytes(@"C:\name_of_directory\MyFile.txt");
            using (FileStream stream = File.OpenRead(@"C:\name_of_directory\MyFile.txt"))
            {
                byte[] recievedData = new byte[stream.Length];
                stream.Read(recievedData, 0, recievedData.Length);

                string recievedText = Encoding.UTF32.GetString(recievedData);
            }

            using (StreamWriter writer = new StreamWriter(File.Open(@"C:\name_of_directory\MyFile.txt", FileMode.Append)))
            {
                string sendText = "HeLLo";
                writer.WriteLine(sendText);
            }

            using (StreamReader reader = new StreamReader(File.Open(@"C:\name_of_directory\MyFile.txt", FileMode.Open)))
            {
                string recievedText = "";
                recievedText = reader.ReadToEnd();
            }

            using (BinaryWriter writer = new BinaryWriter(new FileStream(@"C:\name_of_directory\data.bin", FileMode.OpenOrCreate)))
            {
                var person = new { Name = "Jack", Age = 20, Sex = true };
                writer.Write(person.Name);
                writer.Write(person.Age);
                writer.Write(person.Sex);

            }

            using (BinaryReader reader = new BinaryReader(new FileStream(@"C:\name_of_directory\data.bin", FileMode.OpenOrCreate)))
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();
                bool sex = reader.ReadBoolean();

                var person = new { Name = "", Age = -1, Sex = false };
            }


            //var drives = DriveInfo.GetDrives();

            //Directory.CreateDirectory(@"C:\name_of_directory");
            //DirectoryInfo dirinfo = new DirectoryInfo(@"C:\name_of_directory");

            //if (Directory.Exists(@"C:\name_of_directory"))
            //{
            //    File.Create(@"C:\name_of_directory\new_file_name.txt");
            //    FileInfo fileInfo = new FileInfo(@"C:\name_of_directory\new_file_name.txt");


            //}



        }
    }
}
