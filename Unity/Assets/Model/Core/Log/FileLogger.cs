using System.IO;

namespace ET
{
    public class FileLogger: ILog
    {
        private readonly StreamWriter stream;

        public FileLogger(string path)
        {
            stream = new StreamWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite));
            stream.AutoFlush = true;
        }

        public void Trace(string message)
        {
            stream.WriteLine(message);
            stream.Flush();
        }

        public void Warning(string message)
        {
            stream.WriteLine(message);
            stream.Flush();
        }

        public void Info(string message)
        {
            stream.WriteLine(message);
            stream.Flush();
        }

        public void Debug(string message)
        {
            stream.WriteLine(message);
            stream.Flush();
        }

        public void Error(string message)
        {
            stream.WriteLine(message);
            stream.Flush();
        }

        public void Trace(string message, params object[] args)
        {
            stream.WriteLine(message, args);
            stream.Flush();
        }

        public void Warning(string message, params object[] args)
        {
            stream.WriteLine(message, args);
            stream.Flush();
        }

        public void Info(string message, params object[] args)
        {
            stream.WriteLine(message, args);
            stream.Flush();
        }

        public void Debug(string message, params object[] args)
        {
            stream.WriteLine(message, args);
            stream.Flush();
        }

        public void Error(string message, params object[] args)
        {
            stream.WriteLine(message, args);
            stream.Flush();
        }

        public void Fatal(string message, params object[] args)
        {
            stream.WriteLine(message, args);
            stream.Flush();
        }
    }
}