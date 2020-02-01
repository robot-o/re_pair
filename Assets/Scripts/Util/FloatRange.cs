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

    }

}