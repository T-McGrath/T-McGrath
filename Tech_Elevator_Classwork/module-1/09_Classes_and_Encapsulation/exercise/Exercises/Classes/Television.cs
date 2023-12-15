namespace Exercises.Classes
{
    public class Television
    {
        public bool IsOn { get; private set; } = false;
        public int CurrentChannel { get; private set; } = 3;
        public int CurrentVolume { get; private set; } = 2;

        public void TurnOff()
        {
            if(IsOn)
            {
                IsOn = !IsOn;
            }
        }

        public void TurnOn()
        {
            if(!IsOn)
            {
                IsOn = !IsOn;
                CurrentChannel = 3;
                CurrentVolume = 2;
            }
        }

        public void ChangeChannel(int newChannel)
        {
            if(IsOn && newChannel > 3 && newChannel < 18)
            {
                CurrentChannel = newChannel;
            }
        }

        public void ChannelUp()
        {
            if(IsOn)
            {
                if(CurrentChannel < 18)
                {
                    CurrentChannel++;
                }
                else
                {
                    CurrentChannel = 3;
                }                            
            }
        }

        public void ChannelDown()
        {
            if(IsOn)
            {
                if (CurrentChannel >= 4)
                {
                    CurrentChannel--;
                }
                else
                {
                    CurrentChannel = 18;
                }
            }
        }

        public void RaiseVolume()
        {
            if(IsOn)
            {
                if(CurrentVolume < 10)
                {
                    CurrentVolume++;
                }
            }
        }

        public void LowerVolume()
        {
            if(IsOn)
            {
                if(CurrentVolume > 0)
                {
                    CurrentVolume--;
                }
            }
        }
    }
}
