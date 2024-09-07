using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public class Scanner
    {
        public event EventHandler<FileArgs>? FileFound;

        public bool ScanDirectory(string path)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                var args = new FileArgs(file);
                OnFileFound(args);

                // Отмена поиска
                if (args.Cancel) 
                    return false;
            }

            foreach (var directory in Directory.GetDirectories(path))
            {
                // Рекурсия для подкаталогов
                if (!ScanDirectory(directory)) 
                    return false;
            }

            return true;
        }

        protected virtual void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }
    }
}
