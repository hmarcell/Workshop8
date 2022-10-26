using System;
using System.ComponentModel;

namespace Workshop8_Client
{
    public class FolderEvent : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id")); }
        }

        private string eventType;
        
        public string EventType
        {
            get { return eventType; }
            set { eventType = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EventType")); }
        }

        private DateTime eventDate;

        public DateTime EventDate
        {
            get { return eventDate; }
            set { eventDate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EventDate")); }
        }

        private string folderPath;

        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FolderPath")); }
        }

    }
}