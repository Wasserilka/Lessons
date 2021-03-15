using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    public class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public ToDo(string title)
        {
            Title = title;
            IsDone = false;
        }
        public ToDo()
        {

        }
    }
}
