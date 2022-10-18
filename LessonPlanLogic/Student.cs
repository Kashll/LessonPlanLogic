using System;
using System.Collections.Generic;

namespace LessonPlanLogic
{
    public class Student
    {
        public Student(string name, DateTime startDate)
        {
            Name = name;
            StartDate = startDate;
            StudentTopics = new StudentTopics();
        }

        public Student(string name, DateTime startDate, List<TopicAchievementLevel> topicAchievements)
        {
            Name = name;
            StartDate = startDate;
            StudentTopics = new StudentTopics(topicAchievements);
        }

        public string Name { get; set; }

        public DateTime StartDate { get; }

        public StudentTopics StudentTopics { get; }
    }
}