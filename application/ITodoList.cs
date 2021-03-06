using System;

namespace Application 
{
    /// <summary>
    /// A todo list.
    /// Has todo elements.
    /// </summary>
    public interface ITodoList 
    {
        /// <summary>
        /// Add a new todo element to the list
        /// </summary>
        /// <param name="description"> Description of what should be done</param>
        void AddElement(string description);

        /// <summary>
        /// Marks a element as done
        /// </summary>
        /// <param name="id"> Id of the todo element to be marked as done</param>
        void DoElement(string id);

        /// <summary>
        /// Prints todo elemens that is not marked as done
        /// </summary>
        void PrintElements();

        /// <summary>
        /// Returns the number of todos in list
        /// </summary>
        /// <returns>Returns size of list</returns>
        int GetSize();

        /// <summary>
        /// Saves the list of todo elements to a JSON file
        /// </summary>
        void Save();

        /// <summary>
        /// Loads a JSON file with elements if it exists
        /// </summary>
        void Load();

        /// <summary>
        /// Returns an array of all Todo elements in list
        /// </summary>
        /// <returns>Returns array of all elements in list</returns>
        ITodoElement[] GetTodoElements();
    }
}