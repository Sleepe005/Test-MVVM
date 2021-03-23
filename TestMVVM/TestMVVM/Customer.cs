using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestMVVM
{
    public class Customer : INotifyPropertyChanged
    {
        private string name;
        private bool haveDate;
        private DateTime date;
        private bool isDo;
        private int important;

        public Customer(string name, DateTime date, int important)
        {
            this.name = name;
            this.date = date;
            this.isDo = false;
            this.important = important;
            this.haveDate = true;
        }

        public Customer(string name, int important)
        {
            this.name = name;
            this.isDo = false;
            this.important = important;
            this.haveDate = false;
        }

        public string Name { get => this.name; }
        public int Important { get => this.important; }
        public bool HaveDate { get => this.haveDate; }

        public string dateToString {
            get
            {
                // Если назначено время, то возвращаем date, если нет, то "без времени"
                if (HaveDate)
                {
                    return $"{this.date.Day}.{this.date.Month} до {this.date.Hour}:{this.date.Minute}";
                }
                else
                {
                    return "без времени";
                }
            }
        }

        public bool IsDo {
            get
            {
                return this.isDo;
            }

            set
            {
                this.isDo = value;
                OnPropertyChanged("IsDo"); //Если свойство меняется, вызывается метод, который уведомляет об изменении модели
                OnPropertyChanged("Color"); //Если изменено несколько значений, можно вызвать дополнительный метод
            }
        }

    
        public string Color
        {
            get
            {
                if (Important == 1)
                {
                    return "#BD3246";
                }
                else if (Important == 2)
                {
                    return "#FE8A71";
                }
                else if (DateTime.Now.CompareTo(this.date) == -1)
                {
                    return "#750020";
                }
                else
                {
                   return "#0E9AA7";
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; //Событие, которое будет вызвано при изменении модели 
        public void OnPropertyChanged([CallerMemberName]string prop = "") //Метод, который скажет ViewModel, что нужно передать виду новые данные
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
