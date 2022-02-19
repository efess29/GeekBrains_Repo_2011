using System;

namespace Lesson_5_Task5
{
    /// <summary>
    /// Представляет свойства и методы для работы с классом "Задачи"
    /// </summary>
    public class ToDo
    {
        public ToDo()
        {
        }

        public ToDo(int id, string title, bool isDone)
        {
            Id = id;
            Title = title;
            IsDone = isDone;
        }

        /// <summary>
        /// Получает или задает ИД (порядковый номер) задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Получает или задает наименование задачи
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Получаете или задает признак выполнено/не выполнено
        /// </summary>
        public bool IsDone { get; set; }

    }
}
