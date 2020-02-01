namespace Util
{
    [System.Serializable]
    public class FloatRange : Util.Range<float>
    {
        public FloatRange()
        {
            this.min = 0f;
            this.max = 1f;
        }

        public FloatRange(float _min, float _max)
        {
            this.min = _min;
            this.max = _max;
        }

    }

}