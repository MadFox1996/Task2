using Task2.DataModel;
using Task2.Interfaces;

namespace Task2.Services
{
    public class TodolistService : ITodolistService
    {
        private int _id = 0;
        private List<TodolistItem> TodoList { get; set; } = [];
        public TodolistService()
        {
            Post(new TodolistItem { Title = "Task1", IsCompleted = true });
            Post(new TodolistItem { Title = "Task2", IsCompleted = false });
            Post(new TodolistItem { Title = "Task3", IsCompleted = false });
        }

        public List<TodolistItem> Get()
        {
            return TodoList;
        }

        public TodolistItem? Get(int id)
        {
            return TodoList.FirstOrDefault(x => x.Id == id);
        }

        public int? Put(TodolistItem item)
        {
            var itemForUpdate = TodoList.FirstOrDefault(x => x.Id == item.Id);
            if (itemForUpdate != null)
            {
                itemForUpdate.Title = item.Title;
                itemForUpdate.IsCompleted = item.IsCompleted;
                return itemForUpdate.Id;
            }
            else
            {
                return null;
            }
        }

        public int Post(TodolistItem item)
        {
            item.Id = ++_id;
            TodoList.Add(item);
            return _id;
        }

        public bool Delete(int id)
        {
            var itemToRemove = TodoList.FirstOrDefault(x => x.Id == id);
            if (itemToRemove != null)
            {
                TodoList.Remove(itemToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}