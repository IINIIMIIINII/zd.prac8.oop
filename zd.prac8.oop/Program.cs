using System;
using System.Threading;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;
Random rnd = new Random();
double[] A = new double[10];
double sum = 0;
double product = 1;

// Заповнення масиву випадковими числами
for (int i = 0; i < A.Length; i++) {
    A[i] = rnd.NextDouble() * 49.98 + 0.01;
}

// Виведення масиву
Console.WriteLine("Масив:");
for (int i = 0; i < A.Length; i++) {
    Console.Write($"{A[i]:F2} ");
}

// Потік T0 - сума
Thread T0 = new Thread(() => {
    for (int i = 0; i < A.Length; i++) {
        if (A[i] > 15) {sum += A[i];}
    }
});

// Потік T1 - добуток
Thread T1 = new Thread(() => {
    for (int i = 0; i < A.Length; i++) {
        if (A[i] < 10) {product *= A[i];}
    }
});

// Запуск потоків
T0.Start();
T1.Start();
// Очікування завершення потоків
T0.Join();
T1.Join();
// Виведення результатів
Console.WriteLine("\n\nСума чисел більших за 15: " + sum);
Console.WriteLine("Добуток чисел менших за 10: " + product);