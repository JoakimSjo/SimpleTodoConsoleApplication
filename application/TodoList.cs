using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace application
{
    public class TodoList : ITodoList
    {
        private readonly string ErrorFormatString = "ERROR: {0}";
        private readonly string InfoFormatString = "INFO: {0}";

        public List<ITodoElement> elements;

        public TodoList()
        {
            if (File.Exists("data.json"))
            {
                Load();
            }
            else
            {
                elements = new List<ITodoElement>();
            }
        }

        public void AddElement(string description)
        {
            int id = elements.Count;
            ITodoElement newTodo = new TodoElement(id, description);

            elements.Add(newTodo);

            Save();

            Console.WriteLine(newTodo);
        }

        public void DoElement(string s)
        {
            int id = Int32.Parse(s);

            if (id > elements.Count)
            {
                Console.WriteLine(string.Format(InfoFormatString, "Id is not in list."));
                return;
            }

            ITodoElement elementToComplete = elements[id];

            if (elementToComplete.IsDone())
            {
                Console.WriteLine(string.Format(InfoFormatString, "Todo element is already marked as done."));
                return;
            }

            elementToComplete.MarkAsDone();

            Console.WriteLine("Completed {0}", elementToComplete);

            Save();
        }

        public void PrintElements()
        {
            bool allDone = !elements.Any(element => element.IsDone() == false);

            if(allDone)
            {
                Console.WriteLine(string.Format(InfoFormatString, "All elements is marked as done."));
            }

            foreach (ITodoElement element in elements)
            {
                if (!element.IsDone())
                {
                    Console.WriteLine(element);
                }
            }
        }

        public void Load()
        {
            using (StreamReader file = new StreamReader("data.json"))
            {
                string r = file.ReadToEnd();
                JsonConverter[] converters = { new TodoElementConverter() };

                try
                {
                    elements = JsonConvert.DeserializeObject<List<ITodoElement>>(r, converters: converters);
                }
                catch (JsonSerializationException e)
                {
                    Console.WriteLine(string.Format(ErrorFormatString, e.Message));
                    Console.WriteLine("Creating new todo list");
                    elements = new List<ITodoElement>();
                }
            }
        }

        public void Save()
        {
            using (StreamWriter file = new StreamWriter("data.json"))
            {
                var settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;

                try
                {
                    string data = JsonConvert.SerializeObject(elements, formatting: Formatting.Indented, settings: settings);
                    file.Write(data);
                }
                catch (JsonSerializationException e)
                {
                    Console.WriteLine(string.Format(ErrorFormatString, e.Message));
                    Console.WriteLine(string.Format(ErrorFormatString, "Failed to save. Dumping elements in console"));

                    foreach (ITodoElement TodoElement in elements)
                    {
                        Console.WriteLine(TodoElement);
                    }
                }
            }
        }

        public int GetSize()
        {
            return elements.Count;
        }

        public ITodoElement[] GetTodoElements()
        {
            return elements.ToArray();
        }
    }
}