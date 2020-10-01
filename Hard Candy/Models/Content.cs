using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Hard_Candy.Models
{
    public enum ContentType
    {
        Directory, File
    }

    public class Content : INotifyPropertyChanged
    {
        private ContentType type;
        private string name;
        private BitmapSource image;

        public ContentType Type
        {
            get { return type; }
        }

        public string Name
        {
            get { return name; }
        }

        public BitmapSource Image
        {
            get { return image; }
        }

        public long Size
        {
            get
            {
                switch(type)
                {
                    case ContentType.Directory:
                        long size = 0;

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Content(ContentType type, string path)
        {
            this.type = type;
            switch (type)
            {
                case ContentType.Directory:
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    if (directoryInfo.Exists == false)
                        throw new DirectoryNotFoundException();
                    name = directoryInfo.Name;
                    break;
                case ContentType.File:
                    FileInfo fileInfo = new FileInfo(path);
                    if (fileInfo.Exists == false)
                        throw new FileNotFoundException();
                    name = fileInfo.Name;
                    break;
            }
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
