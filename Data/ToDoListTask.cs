using System;
namespace todolist_blazor_app.Data
{
    public class ToDoListTask
    {
        public int? id { get; set; }

        public string? text { get; set; }

        public bool done { get; set; }

        public ToDoListTask(string? text, bool done)
        {
            this.text = text;
            this.done = done;
        }

        public void TaskCompleted()
        {
            this.done = true;
        }
        public void TaskNotCompleted()
        {
            this.done = false;
        }
    }
}

