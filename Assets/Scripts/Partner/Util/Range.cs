using System;

namespace Util
{
    /// <summary>The Range class. graciously stolen from https://stackoverflow.com/questions/5343006/is-there-a-c-sharp-type-for-representing-an-integer-range</summary>
    /// <typeparam name="T">Generic parameter.</typeparam>
    [Serializable]
    public class Range<T> where T : IComparable<T>
    {

        public Range()
        {
            this.min = default(T);
            this.max = default(T);
        }

        public Range(T _min, T _max)
        {
            this.min = _min;
            this.max = _max;
        }

        /// <summary>min value of the range.</summary>
        public T min;
        /// <summary>max value of the range.</summary>
        public T max;

        /// <summary>Presents the Range in readable format.</summary>
        /// <returns>String representation of the Range</returns>
        public override string ToString() => $"[{this.min} - {this.max}]";

        /// <summary>Determines if the range is valid.</summary>
        /// <returns>True if range is valid, else false</returns>
        public bool IsValid => this.min.CompareTo(this.max) <= 0;

        /// <summary>Determines if the provided value is inside the range.</summary>
        /// <param name="value">The value to test</param>
        /// <returns>True if the value is inside Range, else false</returns>
        public bool ContainsValue(T value) => (this.min.CompareTo(value) <= 0) && (value.CompareTo(this.max) <= 0);

        /// <summary>Determines if this Range is inside the bounds of another range.</summary>
        /// <param name="Range">The parent range to test on</param>
        /// <returns>True if range is inclusive, else false</returns>
        public bool IsInsideRange(Util.Range<T> range) => this.IsValid&& range.IsValid&& range.ContainsValue(this.min) && range.ContainsValue(this.max);

        /// <summary>Determines if another range is inside the bounds of this range.</summary>
        /// <param name="Range">The child range to test</param>
        /// <returns>True if range is inside, else false</returns>
        public bool ContainsRange(Util.Range<T> range) => this.IsValid&& range.IsValid&& this.ContainsValue(range.min) && this.ContainsValue(range.max);
    }
}