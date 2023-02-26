using System;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

internal class FileWork
{
    public static class BinFile<T>
    {
        public static void SaveInBinaryFormat(object objGraph, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
        }
        public static T LoadFromBinaryFile(string fileName)
        {
            
                T Result;
                BinaryFormatter binFormat = new BinaryFormatter();

                using (Stream fStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
                {
                    /*var filelength = new FileInfo(fileName).Length;
                    if (filelength != 0)
                    {*/
                        Result = (T)binFormat.Deserialize(fStream);
                    //}
                return Result;
            }
        }
    }
}
