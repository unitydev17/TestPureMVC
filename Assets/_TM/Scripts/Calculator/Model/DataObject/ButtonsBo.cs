using com.calculator.utils;

namespace com.calculator.model
{
    public class ButtonsBo
    {
        public bool minusPushed;
        public bool plusPushed;
        public bool multiplyPushed;
        public bool dividePushed;

        public ButtonsBo(int state)
        {
            Set(state);
        }

        public void Set(int state)
        {
            var values = state.Convert(4);
            plusPushed = values[0];
            minusPushed = values[1];
            multiplyPushed = values[2];
            dividePushed = values[3];
        }
    }
}