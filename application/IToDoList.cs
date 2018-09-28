using System;

namespace application {
    /// <summary>
    /// A todo list.
    /// Has todo elemens.
    /// </summary>
    public interface IToDoList {
        /// <summary>
        /// Add a new todo element to the list
        /// </summary>
        /// <param name="description"> Description of what should be done </param>
        void AddElement(string description);

        /// <summary>
        /// Marks a element as done
        /// </summary>
        /// <param name="id"> Id of the todo element to be marked as done </param>
        void DoElement(int id);

        /// <summary>
        /// Prints todo elemens that is not marked as done
        /// </summary>
        void PrintElements();
    }
}