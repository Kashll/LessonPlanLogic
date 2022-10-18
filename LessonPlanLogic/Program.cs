using System;
using System.Collections.Generic;

namespace LessonPlanLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Student> students = GetStudents();
            LessonTopicSuggestion lessonTopicSuggestion = SuggestTopics(students);
            lessonTopicSuggestion.PrintSuggestions();

            Console.ReadKey();
        }

        public static LessonTopicSuggestion SuggestTopics(List<Student> students)
        {
            LessonTopicSuggestion lessonTopicSuggestion = new LessonTopicSuggestion();
            return lessonTopicSuggestion;
        }

        private static List<Student> GetStudents()
        {
            return new List<Student>();
        }
    }
}
