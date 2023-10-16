internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Эта программка высчитывает количество присваиваний при нахождении максимального элемента в массиве целочисленных неодинаковых чисел размером 10^7");
        Console.Write("Введите количество эксперементов: ");
        int countOfExperiments = int.Parse(Console.ReadLine());
        float avgCount = 0;
        int[] resultArr = new int[countOfExperiments];
        for (int i = 0; i < countOfExperiments; i++)
        {
            int[] array = new int[10000000];
            GiveValuesToArray(array);
            int counter = FindMax(array);
            avgCount += counter;
            resultArr[i] = counter;
            Console.WriteLine($"Эксперемент №{i + 1}: {counter} присваиваний");
        }
        avgCount /= countOfExperiments;
        Console.WriteLine($"Среднее количество присваиваний: {avgCount}");
        PrintGrafic(resultArr);
    }

    static int FindMax(int[] array)
    {
        int counter = 0;
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                counter++;
            }
        }
        return counter;
    }

    static void GiveValuesToArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }
        ShuffleArray(array);
    }

    static void ShuffleArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Random random = new Random();
            int index = random.Next(i + 1);
            int temp = array[i];
            array[i] = array[index];
            array[index] = temp;
        }
    }

    static void PrintGrafic(int[] array)
    {
        var plt = new ScottPlot.Plot(800, 600);
        plt.AddSignal(array, sampleRate: array.Length);
        plt.Title("График результатов эксперементов");
        plt.XLabel("Эксперемент");
        plt.YLabel("Количество присваиваний");
        plt.SaveFig("ResultLerner.png");
    }
}