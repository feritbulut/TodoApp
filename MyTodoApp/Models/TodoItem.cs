using SQLite;
using System.ComponentModel;

namespace MyTodoApp.Models
{
    public class TodoItem : INotifyPropertyChanged
    {
        private bool done;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Notes { get; set; }

        
        public bool Done
        {
            get => done;
            set
            {
                if (done != value)
                {
                    done = value;
                    OnPropertyChanged(nameof(Done)); 
                }
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
