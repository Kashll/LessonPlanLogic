namespace LessonPlanLogic
{
    public class TopicAchievementLevel
    {
        public TopicAchievementLevel(Topic topic)
        {
            Topic = topic;
            Level = AchievementLevels.None;
        }

        public TopicAchievementLevel(Topic topic, AchievementLevels level)
        {
            Topic = topic;
            Level = level;
        }

        public Topic Topic { get; }

        public AchievementLevels Level { get; set; }
    }
}