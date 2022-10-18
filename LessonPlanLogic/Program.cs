using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonPlanLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Suggesting Lessons!");

            List<Student> students = GetStudents();
            LessonTopicSuggestion lessonTopicSuggestion = SuggestTopics(students);
            lessonTopicSuggestion.PrintSuggestions();

            Console.ReadKey();
        }

        public static LessonTopicSuggestion SuggestTopics(List<Student> students)
        {
            LessonTopicSuggestion lessonTopicSuggestion = new LessonTopicSuggestion();

            Dictionary<Topic, int> qualifiedStudentCountByTopic = GetTopicCountsByAchievementLevel(students, AchievementLevels.Qualified);
            // Dictionary<Topic, int> introducedStudentCountByTopic = GetTopicCountsByAchievementLevel(students, AchievementLevels.Introduced);

            // get topics with least number of qualified students
            int minimumNumberOfQualifiedStudents = qualifiedStudentCountByTopic.Values.Min();
            HashSet<Topic> topics = qualifiedStudentCountByTopic.Where(x => x.Value == minimumNumberOfQualifiedStudents).Select(x => x.Key).ToHashSet();

            foreach (Topic topic in topics)
            {
                lessonTopicSuggestion.AddSuggestionToFront(topic);
            }

            return lessonTopicSuggestion;
        }

        private static Dictionary<Topic, int> GetTopicCountsByAchievementLevel(List<Student> students, AchievementLevels minimumAchievement)
        {
            Dictionary<Topic, int> qualifiedStudentsByTopic = new Dictionary<Topic, int>(new TopicEqualityComparer());
            foreach (Student student in students)
            {
                List<TopicAchievementLevel> qualifiedTopics =
                    student.StudentTopics.Topics.Where(x => x.Level >= minimumAchievement).ToList();

                qualifiedTopics.ForEach(x =>
                {
                    if (qualifiedStudentsByTopic.ContainsKey(x.Topic))
                    {
                        qualifiedStudentsByTopic[x.Topic]++;
                    }
                    else
                    {
                        qualifiedStudentsByTopic.Add(x.Topic, 1);
                    }
                });
            }

            return qualifiedStudentsByTopic;
        }

        private static List<Student> GetStudents()
        {
            return new List<Student>
            {
                GetQualifiedStudent("Peter"),
                GetQualifiedStudent("Tim"),
                GetUnQualifiedStudent("Jeremy")
            };
        }

        private static Student GetQualifiedStudent(string name)
        {
            List<TopicAchievementLevel> achievementLevels = new List<TopicAchievementLevel>
            {
                new TopicAchievementLevel(new Topic("Knight"), AchievementLevels.Qualified),
                new TopicAchievementLevel(new Topic("Bishop"), AchievementLevels.Qualified),
                new TopicAchievementLevel(new Topic("The Center"), AchievementLevels.Qualified),
                new TopicAchievementLevel(new Topic("Active Moves"), AchievementLevels.Qualified)
            };

            return new Student(name, DateTime.UtcNow, achievementLevels);
        }

        private static Student GetUnQualifiedStudent(string name)
        {
            List<TopicAchievementLevel> achievementLevels = new List<TopicAchievementLevel>
            {
                new TopicAchievementLevel(new Topic("Knight"), AchievementLevels.Qualified),
                new TopicAchievementLevel(new Topic("Bishop"), AchievementLevels.None),
                new TopicAchievementLevel(new Topic("The Center"), AchievementLevels.Qualified),
                new TopicAchievementLevel(new Topic("Active Moves"), AchievementLevels.Qualified)
            };

            return new Student(name, DateTime.UtcNow, achievementLevels);
        }
    }
}
