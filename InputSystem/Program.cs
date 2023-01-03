﻿using System;
using System.Threading;
using System.Collections.Concurrent;

namespace InputSystem
{
    public class Program
    {
        // Coleção thread-safe, usa internamente uma Queue (primeira tecla a
        // entrar é a primeira a sair)
        private static BlockingCollection<ConsoleKey>input;

        private static void Main()
        {
            Thread producer = new Thread(ReadKeys);
            Thread consumer = new Thread(ShowKeyOnScreen);

            input = new BlockingCollection<ConsoleKey>();

            Console.WriteLine("Podes começar a carregar nas teclas");

            producer.Start();
            consumer.Start();

            producer.Join();
            consumer.Join();

            //--> Código para esperar que as threads terminem aqui

            Console.WriteLine("Obrigado!");
        }

        // Método produtor:
        // Lé as teclas do teclado e coloca-as na fila
        private static void ReadKeys()
        {
            ConsoleKey ck;
            do
            {
                ck = Console.ReadKey(true).key;
                input.Add(ck);

            } while (ck != ConsoleKey.Escape);

        }

        // Método consumidor:
        // Obtém/retira as teclas da fila, e apresenta informação no ecrã
        private static void ShowKeyOnScreen()
        {
            ConsoleKey ck;
            while ((ck = input.Take()) != ConsoleKey.Escape)
            {
                switch (ck)
                {
                    case ConsoleKey.W:
                        Console.WriteLine("Cima");
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine("Esquerda");
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Baixo");
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("Direita");
                        break;                   
                }
            }
        }
    }
}