namespace Exercises.Classes
{
    public class Television
    {
        public bool IsOn
        {
            get;
            private set;
        }
        public int CurrentChannel
        {
            get; private set;
        }
        public int CurrentVolume
        {
            get;
            private set;
        }

        public Television()
        {
            IsOn = false;
            CurrentVolume = 2;
            CurrentChannel = 3;
        }

        public void TurnOff()
        {
            IsOn = false;
            CurrentChannel = 3;
            CurrentVolume = 2;
        }
        public void TurnOn()
        {
            IsOn = true;
            //CurrentChannel = 3;
            //CurrentVolume = 2;
        }
        public void ChangeChannel(int newChannel)
        {
            if (IsOn && (newChannel >= 3 && newChannel <= 18))
            {
                CurrentChannel = newChannel;
            }
        }
        public void ChannelUp()
        {
            if (IsOn)
            {
                if (CurrentChannel + 1 > 18)
                {
                    CurrentChannel = 3;
                }
                else { CurrentChannel = CurrentChannel + 1; }
            }
        }
        public void ChannelDown()
        {
            if (IsOn) if (CurrentChannel - 1 < 3)
                {
                    CurrentChannel = 18;
                }
                else 
                { 
                    CurrentChannel = CurrentChannel - 1; 
                }
        }
        public void RaiseVolume() 
        { 
            if (IsOn && CurrentVolume != 10) 
            { 
                CurrentVolume = CurrentVolume + 1; 
            } 
        }
        public void LowerVolume()
        {
            if (IsOn && CurrentVolume != 0)
            {
                CurrentVolume = CurrentVolume - 1;
            }
        }

    }
}
