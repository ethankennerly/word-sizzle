using Finegamedesign.Utils;

namespace Finegamedesign.WordSizzle
{
    [System.Serializable]
    public sealed class AnagramModel
    {
        public string selection;

        public string word;

        public bool isPopulateNext = false;
        public bool isPopulateNow = false;
        public bool isComplete = false;
        private bool wasComplete = false;
        private bool isFull = false;

        public string state = "none";
        public string winBeginState = "win_begin";
        public string winEndState = "win_end";

        public Words words = new Words();
        public WordLevels levels = new WordLevels();

        public Timer timer = new Timer();
        public TimerTextDeck textDeck = new TimerTextDeck();

        public void Setup()
        {
            textDeck.timer = timer;
            textDeck.Setup();
            words.Setup();
            levels.Setup();
            isPopulateNext = false;
            isPopulateNow = false;
            Populate();
        }

        public void Populate(string nextWord = null)
        {
            if (nextWord == null)
            {
                levels.Next();
                nextWord = levels.Current();
            }
            word = nextWord;
            selection = "";
            isComplete = false;
            wasComplete = false;
            state = state == winBeginState ? winEndState : "play_begin";
            timer.Reset();
            isPopulateNext = true;
        }

        public void Update(float deltaTime)
        {
            isPopulateNow = isPopulateNext;
            isPopulateNext = false;
            timer.isEnabled = !isComplete;
            timer.Update(deltaTime);
            UpdateComplete();
        }

        private void UpdateComplete()
        {
            isFull = DataUtil.Length(selection) == DataUtil.Length(word);
            if (isFull)
            {
                wasComplete = isComplete;
                isComplete = words.all.ContainsKey(selection);
                if (isComplete && !wasComplete)
                {
                    state = winBeginState;
                    textDeck.Select();
                }
            }
        }
    }
}
