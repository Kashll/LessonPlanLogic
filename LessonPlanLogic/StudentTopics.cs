using System.Collections.Generic;
using System.Linq;

namespace LessonPlanLogic
{
    public class StudentTopics
    {
        public StudentTopics()
        {
            List<TopicAchievementLevel> topics = CreateTopicAchievementLevels();

            Topics = topics;
        }

        public StudentTopics(List<TopicAchievementLevel> topicAchievementLevels)
        {
            List<TopicAchievementLevel> topics = CreateTopicAchievementLevels();

            foreach (TopicAchievementLevel topicAchievementLevel in topicAchievementLevels)
            {
                TopicAchievementLevel matchingTopic = topics.SingleOrDefault(x => x.Topic.Name == topicAchievementLevel.Topic.Name);
                if (matchingTopic != null)
                {
                    matchingTopic.Level = topicAchievementLevel.Level;
                }
            }

            Topics = topics;
        }

        private static List<TopicAchievementLevel> CreateTopicAchievementLevels()
        {
            List<TopicAchievementLevel> topics = new List<TopicAchievementLevel>()
            {
                new TopicAchievementLevel(new Topic("Knight", new List<LifeSkills> {LifeSkills.Determination, LifeSkills.Grit})),
                new TopicAchievementLevel(new Topic("Bishop")),
                new TopicAchievementLevel(new Topic("The Center")),
                new TopicAchievementLevel(new Topic("Active Moves")),
            };

            return topics;
        }

        public List<TopicAchievementLevel> Topics { get; }
    }
}