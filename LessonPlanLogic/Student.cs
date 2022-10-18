using System;
using System.Collections.Generic;
using System.Linq;

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

        public TopicsAtLevel GetLeastQualifiedTopics()
        {
            IGrouping<AchievementLevels, TopicAchievementLevel> lowestQualifiedTopicGroup = StudentTopics.Topics.GroupBy(x => x.Level).OrderBy(x => x.Key).FirstOrDefault();
            List<Topic> lowestQualifiedTopics = lowestQualifiedTopicGroup.Select(x => x.Topic).ToList();
            return new TopicsAtLevel(lowestQualifiedTopics, lowestQualifiedTopicGroup.Key);
        }
    }
}