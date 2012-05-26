using System;
using System.Collections.Generic;
using System.Linq;

namespace SorterMaraton
{
    class Program
    {
        /**
         * Returns an Image object that can then be painted on the screen. 
         * The url argument must specify an absolute {@link URL}. The name
         * argument is a specifier that is relative to the url argument. 
         * <p>
         * This method always returns immediately, whether or not the 
         * image exists. When this applet attempts to draw the image on
         * the screen, the data will be loaded. The graphics primitives 
         * that draw the image will incrementally paint on the screen. 
         *
         * @param  url  an absolute URL giving the base location of the image
         */
        static void Main(string[] args)
        {
            String komut = ""; //Buraya okunacak

            if (args.Length < 1)
            {
                Console.WriteLine("Lütfen geçerli parametre giriniz");
                return;
            }
            else
            {
                komut = args[0];
            }

            //Komut başlangıcını kontrol edelim
            if (komut.StartsWith("Sırala ") || komut.StartsWith("Sirala "))
            {
                int komutLength = komut.Length - 7;
                komut = komut.Substring(7, komutLength);

                if (komutLength < 1)
                {
                    Console.WriteLine("Sıralamak için eleman girmelisiniz!");
                }
                else
                {
                    islemYap(komut);
                }
            }
            else
            {
                Console.WriteLine("Geçersiz komut!");
                return;
            }
        }

        /**
         * Bu metot içerisinde String olarak gönderilen rakamlar
         * ayrılır ve rakam olmayanlar aradan silinir.
         * Daha sonra MergeSort çağırılarak bu rakamlar sıralanır
         * ve sırasıyla ekrana yazılır.
         *
         * @param  elements arka arkaya , ile ayrılmış rakamlar
         */
        static void islemYap(String elements)
        {
            String[] elementArray = elements.Split(',');
            int elementCount = elementArray.Length;
            LinkedList<int> integerElements = new LinkedList<int>();

            int forcounter = 0;
            foreach (String element in elementArray)
            {
                try
                {
                    integerElements.AddLast(int.Parse(element));
                    forcounter++;
                }
                catch (FormatException fe)
                {
                    //Rakam olmayanları elemek için
                }
            }

            int[] integerArray = integerElements.ToArray<int>();

            //Elemanları sıralayalım
            integerArray = MergeSort(integerArray);

            foreach (int i in integerArray)
            {
                Console.WriteLine(i);
            }
        }


        /**
        * Bu metot verilen integer dizisini küçükten büyüğe sıralar ve yine
        * integer dizisi olarak döndürür.
        * Çalışma süresi O(n.long)
        *
        * @param  a[]  sıralanacak olan integer dizisi
        * @return      küçükten büyüğe sıralanmış integer dizisi
        */
        static int[] MergeSort(int[] a)
        {
            //Sıralamanın en derini veya tek eleman sırala
            if (a.Length == 1)
                return a;

            //Orta elemanın yeri
            int middle = a.Length / 2;

            //Listeyi ikiye böl
            int[] left = new int[middle];

            //Sol kısım
            for (int i = 0; i < middle; i++)
            {
                left[i] = a[i];
            }

            //Sağ kısım
            int[] right = new int[a.Length - middle];
            for (int i = 0; i < a.Length - middle; i++)
            {
                right[i] = a[i + middle];
            }

            //Sol ve sağ listeleri tekrar sırala
            left = MergeSort(left);
            right = MergeSort(right);

            int leftptr = 0;
            int rightptr = 0;

            //Liste daha fazla bölünemiyorsa sıralama bitmiştir

            int[] sorted = new int[a.Length];

            //Sıralanmış listeyi birleştir
            for (int k = 0; k < a.Length; k++)
            {
                if (rightptr == right.Length || ((leftptr < left.Length) && (left[leftptr] <= right[rightptr])))
                {
                    sorted[k] = left[leftptr];
                    leftptr++;
                }
                else if (leftptr == left.Length || ((rightptr < right.Length) && (right[rightptr] <= left[leftptr])))
                {
                    sorted[k] = right[rightptr];
                    rightptr++;
                }
            }
            return sorted;
        }
    }
}
