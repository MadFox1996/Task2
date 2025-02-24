using Task2.DataModel;

namespace Task2.Interfaces
{
    public interface ITodolistService
    {
        List<TodolistItem> Get();

        TodolistItem? Get(int id);

        int? Put(TodolistItem item);

        int Post(TodolistItem item);

        bool Delete(int id);
    }
}
