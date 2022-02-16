namespace ConsoleApplication {
    public class Item {
        public string Name { get; set; }
        public int DaysRemaining { get; set; }
        public int Quality { get; set; }

        public void IncrementQuality(int value = 1) {
            var qualityNew = Quality + value;
            Quality = qualityNew > 50 ? 50 : qualityNew;
        }

        /// <summary>
        /// Updates current Item Quality to 0
        /// </summary>
        public void SpoilQuality() => Quality = 0;

        public void DecrementQuality(int value = 1) => Quality -= value;

        public void DecrementDaysRemaining() => DaysRemaining -= 1;
    }
}
