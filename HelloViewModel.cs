using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFPart11
{
    public class HelloViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string name;
        public string Name 
        {
            get{ return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string greeting;
        public string Greeting
        {
            get { return greeting; }
            set
            {
                greeting = value;
                NotifyPropertyChanged("Greeting");
            }
        }

        public ICommand cmdSubmitName { get; set; }
        public bool CanExecuteSubmit 
        {
            get { return !string.IsNullOrEmpty(Name); }

        }

        public HelloViewModel()
        {
            cmdSubmitName = new DelegateCommand(ProcessSubmit, () => CanExecuteSubmit);
        }

        private void ProcessSubmit()
        {
            Greeting = $"Hello {Name}";
        }
    }
}
