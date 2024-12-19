namespace SimpleRandom;

public sealed class NoDupNumberProvider {
    private readonly List<int> noDupNumbers;
    private readonly int minValue;
    private readonly int maxValuePlusOne;
    private readonly Lock lockObj = new();

    public NoDupNumberProvider(int minValue, int maxValuePlusOne) {
        if (minValue >= maxValuePlusOne) {
            throw new ArgumentException($"{nameof(minValue)}는 {nameof(maxValuePlusOne)}보다 작아야 합니다.");
        }

        this.minValue = minValue;
        this.maxValuePlusOne = maxValuePlusOne;
        noDupNumbers = new(maxValuePlusOne - minValue);
    }

    public int Capacity {
        get {
            lock (lockObj) {
                return noDupNumbers.Capacity;
            }
        }
    }

    public int GetNumber() {
        lock (lockObj) {
            if (noDupNumbers.Count >= maxValuePlusOne - minValue) {
                throw new InvalidOperationException("모든 숫자를 뽑았습니다.");
            }

            int value;

            do {
                value = Random.Shared.Next(minValue, maxValuePlusOne);
            } while (noDupNumbers.Contains(value));

            noDupNumbers.Add(value);

            return value;
        }
    }
}
