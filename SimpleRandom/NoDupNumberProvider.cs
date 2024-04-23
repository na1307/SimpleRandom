namespace SimpleRandom;

public sealed class NoDupNumberProvider(int minValue, int maxValuePlusOne) {
    private readonly List<int> noDupNumbers = new(maxValuePlusOne - minValue);

    public int Capacity => noDupNumbers.Capacity;

    public async Task<int> GetNumber() {
        if (noDupNumbers.Count >= (maxValuePlusOne - minValue)) {
            throw new NothingToGetException();
        }

        return await Task.Factory.StartNew(getNumber, TaskCreationOptions.LongRunning);
    }

    private int getNumber() {
        int value;

        do {
            value = Random.Shared.Next(minValue, maxValuePlusOne);
        } while (noDupNumbers.Contains(value));

        noDupNumbers.Add(value);

        return value;
    }
}
